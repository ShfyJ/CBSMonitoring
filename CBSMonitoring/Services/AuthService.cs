using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static CBSMonitoring.DTOs.Responses;
using CBSMonitoring.Constants;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Update;
using AutoMapper;
using Serilog.Parsing;
using Microsoft.Extensions.Caching.Memory;

namespace CBSMonitoring.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly EmailService _emailService;
        private readonly IGenericRepository _genericRepository;
        private readonly IPasswordService _passwordService;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserService _applicationUserService;
        private readonly IMapper _mapper;
        private readonly DateTime AccessTokenExpiryTime = DateTime.UtcNow.AddMinutes(30);
        private readonly DateTime TempTokenExpiryTime = DateTime.UtcNow.AddMinutes(10);
        public AuthService(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            EmailService emailService,
            IConfiguration configuration,
            IApplicationUserService applicationUserService,
            IPasswordService passwordService,
            IMapper mapper,
            IGenericRepository genericRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
            _configuration = configuration;
            _applicationUserService = applicationUserService;
            _mapper = mapper;
            _passwordService = passwordService;
            _genericRepository = genericRepository;

        }

        public async Task<Result<RegistrationResponse>> Registeration(RegistrationRequest request)
        {
            try
            {
                var userExists = await _userManager.FindByNameAsync(request.UserName);

                if (userExists != null)
                {
                    return await Result<RegistrationResponse>.FailAsync(StatusCodes.Status400BadRequest, $"Пользователь уже существует!");
                }

                var passwordStrength = _passwordService.CheckPasswordStrength(request.Password);

                if (passwordStrength == "Weak Password")
                {
                    return await Result<RegistrationResponse>.FailAsync(StatusCodes.Status400BadRequest, $"Your password is too weak. Please choose a stronger password.");
                }

                ApplicationUser user = new()
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    FullName = request.FullName,
                    OrganizationId = request.OrganizationId,
                    Position = request.Position,
                    PhoneNumber = request.PhoneNumber,
                    IsActive = true,
                    IsFirstLogin = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var createUserResult = await _userManager.CreateAsync(user, request.Password);
                if (!createUserResult.Succeeded)
                {
                    return await Result<RegistrationResponse>.FailAsync(StatusCodes.Status400BadRequest, $"Создание пользователя не удалось! " +
                        $"Пожалуйста, проверьте данные пользователя и повторите попытку.");
                }

                foreach (var role in request.Roles)
                {
                    if (!await _roleManager.RoleExistsAsync(role))
                        await _roleManager.CreateAsync(new IdentityRole(role));

                    else
                        await _userManager.AddToRoleAsync(user, role);
                }

                var response = _mapper.Map<RegistrationResponse>(request, opt => opt.AfterMap(async (src, dest) =>
                {
                    dest.OrganizationName = (await _userManager.Users.Include(u => u.Organization)
                        .FirstAsync(u => u.Email == user.Email))
                        .Organization.FullName;
                    
                }));

                return await Result<RegistrationResponse>.SuccessAsync(StatusCodes.Status201Created, response, $"Пользователь успешно создан!");
            }
            catch(Exception ex)
            {
                return await Result<RegistrationResponse>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
        public async Task<Result<AuthResponse>> Login(LoginRequest request, IMemoryCache memoryCache)
        {
            try
            {
                // limit
                string cacheKey = $"login_attempts_{request.UserName}";
                int maxAttempts = 5;

                // Check cache for failed attempts
                if (!memoryCache.TryGetValue(cacheKey, out int currentAttempts))
                {
                    currentAttempts = 0;
                }

                // Check if the user has already exceeded the max attempts
                if (currentAttempts >= maxAttempts)
                {
                    return await Result<AuthResponse>.FailAsync(StatusCodes.Status400BadRequest, $"Too many login attempts. Try again later.");
                }

                var user = await _userManager.Users
                                .Include(u => u.Organization)
                                .FirstOrDefaultAsync(u => u.UserName == request.UserName);

                if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    currentAttempts++;

                    // Store updated attempts count with an expiration time
                    memoryCache.Set(cacheKey, currentAttempts, TimeSpan.FromMinutes(15)); // Resets after 15 minutes

                    if (currentAttempts >= maxAttempts)
                    {
                        return await Result<AuthResponse>.FailAsync(StatusCodes.Status400BadRequest,$"Too many login attempts. Try again later.");
                    }

                    return await Result<AuthResponse>.FailAsync(StatusCodes.Status400BadRequest, $"Invalid username or password");                   
                }

                // If validation is successful, remove the attempts from cache
                memoryCache.Remove(cacheKey);

                if (!user.IsActive)
                {
                    return await Result<AuthResponse>.FailAsync(StatusCodes.Status403Forbidden, $"User has no access, please contact Admin");
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                var authClaims = GetAuthClaims(user, userRoles, CustomClaimTypes.TypeAccess);

                if (await _userManager.GetTwoFactorEnabledAsync(user))
                {
                    string cacheTempToken = $"cache_temp_token_{request.UserName}";

                    // Optionally, trigger OTP sending here or let the client call the send-otp endpoint explicitly
                    var tempToken = GenerateToken(authClaims, _configuration["JWT:TempKey"]!, TempTokenExpiryTime);

                    memoryCache.Set(cacheTempToken, tempToken, TimeSpan.FromMinutes(10));

                    var responseData = new AuthResponse(user.UserName!, user.IsFirstLogin, user.TwoFactorEnabled, tempToken);
                    return await Result<AuthResponse>.SuccessAsync(StatusCodes.Status200OK, responseData, "Need two factor authentication!");
                }

                string cacheAccessToken = $"cache_access_token_{request.UserName}";

                string accessToken = GenerateToken(authClaims, _configuration["JWT:AccessKey"]!, AccessTokenExpiryTime);

                memoryCache.Set(cacheAccessToken, accessToken, TimeSpan.FromMinutes(30));

                var responseDataWithToken = new AuthResponse(user.UserName!, user.IsFirstLogin, user.TwoFactorEnabled, accessToken, userRoles);

                return await Result<AuthResponse>.SuccessAsync(StatusCodes.Status200OK, responseDataWithToken, "Successfully authenticated!");
            }

            catch(Exception ex)
            {
                return await Result<AuthResponse>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        public async Task<Result<AuthResponse>> Logout(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var jti = jwtToken.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Jti)?.Value;
            var exp = jwtToken.ValidTo;

            if (!string.IsNullOrEmpty(jti))
            {
                var blacklistedToken = new BlacklistedToken
                {
                    Jti = jti,
                    Expiration = exp
                };

                try
                {
                    await _genericRepository.AddAsync(blacklistedToken);
                }
                catch (Exception ex)
                {
                    return await Result<AuthResponse>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
                }

            }

            return await Result<AuthResponse>.SuccessAsync(StatusCodes.Status200OK, $"Successfully logged out!");

        }
        public async Task<Result<string>> SendOtpEmail(string username, string tempToken)
        {
            if (!ValidateToken(tempToken))
            {
                return await Result<string>.FailAsync(StatusCodes.Status401Unauthorized, "Temp token is Invalid");
            }

            var user = await _userManager.FindByNameAsync(username);
            if (user == null || user.Email == null)
                return await Result<string>.FailAsync(StatusCodes.Status400BadRequest, "Either the user or their email is not available");

            var token = await _userManager.GenerateUserTokenAsync(user, TokenOptions.DefaultEmailProvider, "TwoFactor");

            try
            {
                _emailService.SendEmail(user.Email, "Одноразовый пароль(OTP)", $"Вот ваш OTP: {token}");
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(StatusCodes.Status400BadRequest, ex.Message);
            }

            return await Result<string>.SuccessAsync(StatusCodes.Status200OK, "OTP sent via email.");
        }
        public async Task<Result<AuthResponse>> VerifyOtp(OtpVerificationRequest otpVerificationRequest)
        {
            if (!ValidateToken(otpVerificationRequest.TempToken))
            {
                return await Result<AuthResponse>.FailAsync(StatusCodes.Status401Unauthorized, "Temp token is Invalid");
            }

            var user = await _userManager.Users
                                .Include(u => u.Organization)
                                .FirstOrDefaultAsync(u => u.UserName == otpVerificationRequest.Username);
            if (user == null)
                return await Result<AuthResponse>.FailAsync(StatusCodes.Status400BadRequest, "User not found");

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = GetAuthClaims(user, userRoles, CustomClaimTypes.TypeAccess);

            var isOtpValid = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultEmailProvider, "TwoFactor", otpVerificationRequest.OTP);
            if (isOtpValid)
            {
                // Proceed with login or other actions
                string accessToken = GenerateToken(authClaims, _configuration["JWT:AccessKey"]!, AccessTokenExpiryTime);

                var responseDataWithToken = new AuthResponse(user.UserName!, user.IsFirstLogin, user.TwoFactorEnabled, accessToken, userRoles);

                return await Result<AuthResponse>.SuccessAsync(StatusCodes.Status200OK, responseDataWithToken, "Successfully authenticated!");
                
            }
            else
            {
                return await Result<AuthResponse>.FailAsync(StatusCodes.Status400BadRequest, "Invalid OTP.");
            }
        }

        public async Task<Result<UpdatePasswordResponse>> UpdatePassword(UpdatePasswordRequest request)
        {
            try
            {
                var userResult = await _applicationUserService.GetCurrentUser();
                if (!userResult.Succeeded)
                {
                    return await Result<UpdatePasswordResponse>.FailAsync(userResult.StatusCode, userResult.Messages);
                }

                var flag1 = await _userManager.CheckPasswordAsync(userResult.Data!, request.OldPassword);
                var flag2 = await _userManager.CheckPasswordAsync(userResult.Data!, request.NewPassword);

                if (!flag1)
                {
                    return await Result<UpdatePasswordResponse>.FailAsync(StatusCodes.Status400BadRequest,
                        PasswordUpdateMessage.OldPasswordNotConfirmed);
                }

                if (flag2)
                {
                    return await Result<UpdatePasswordResponse>.FailAsync(StatusCodes.Status400BadRequest,
                        PasswordUpdateMessage.NewAndOldPasswordIdentical);
                }

                var updatePasswordResult = await _userManager.ChangePasswordAsync(userResult.Data!, request.OldPassword, request.NewPassword);

                if (!updatePasswordResult.Succeeded)
                {
                    return await Result<UpdatePasswordResponse>.FailAsync(StatusCodes.Status400BadRequest,
                        new UpdatePasswordResponse(PasswordUpdate.PasswordUpdateFailed,
                        PasswordUpdateMessage.PasswordUpdateFailed));
                }

                userResult.Data!.IsFirstLogin = false;
                await _userManager.UpdateAsync(userResult.Data);

                return await Result<UpdatePasswordResponse>.SuccessAsync(StatusCodes.Status200OK,
                    new UpdatePasswordResponse(PasswordUpdate.PasswordUpdateSucceded,
                    PasswordUpdateMessage.PasswordUpdateSuccceded));
            }

            catch(Exception ex)
            {
                return await Result<UpdatePasswordResponse>.FailAsync(StatusCodes.Status500InternalServerError, ex.Message);
            }

            
        }

        #region private methods
        private bool ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters
            {
                ClockSkew = TimeSpan.Zero,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JWT:ValidIssuer"], //jwtSettings.GetSection("ValidIssuers").Get<string[]>(),
                ValidAudience = _configuration["JWT:ValidAudience"], //jwtSettings.GetSection("ValidAudiences").Get<string[]>(),
                NameClaimType = ClaimTypes.NameIdentifier,
                RoleClaimType = ClaimTypes.Role,
                IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["JWT:TempKey"]!)),
            };

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
                return true;
            }
            catch { return false; }
        }
        private string GenerateToken(IEnumerable<Claim> claims, string secretKey, DateTime expiration)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = expiration,
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private static List<Claim> GetAuthClaims(ApplicationUser user, IList<string> userRoles, string token_type)
        {
            var authClaims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, user.UserName!),
                   new Claim(ClaimTypes.NameIdentifier, user.Id),
                   new Claim(CustomClaimTypes.OrganizationId, user.OrganizationId.ToString()),
                   new Claim(CustomClaimTypes.OrganizationName, user.Organization.FullName),
                   new Claim(CustomClaimTypes.IsFirstLogin, user.IsFirstLogin.ToString()),
                   new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                   new Claim("token_type", token_type)
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            return authClaims;
        }

        #endregion
    }
}
