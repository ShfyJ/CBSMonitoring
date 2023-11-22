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

namespace CBSMonitoring.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserService _applicationUserService;
        public AuthService(UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IConfiguration configuration,
            IApplicationUserService applicationUserService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _applicationUserService = applicationUserService;

        }

        public async Task<Result<string>> Registeration(RegistrationRequest request)
        {
            var userExists = await _userManager.FindByNameAsync(request.UserName);

            if (userExists != null)
            {
                return await Result<string>.FailAsync($"User already exists");
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
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var createUserResult = await _userManager.CreateAsync(user, request.Password);
            if (!createUserResult.Succeeded)
            {
                return await Result<string>.FailAsync($"User creation failed! Please check user details and try again.");
            }

            foreach(var role in request.Roles)
            {
                if (!await _roleManager.RoleExistsAsync(role))
                    await _roleManager.CreateAsync(new IdentityRole(role));

                else
                    await _userManager.AddToRoleAsync(user, role);
            }

            return await Result<string>.SuccessAsync($"User created successfully!");
        }
        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _userManager.Users
                .Include(u => u.Organization)
                .FirstOrDefaultAsync(u => u.UserName == request.UserName);

            if (user == null)
                return await Result<LoginResponse>.FailAsync($"Invalid username");
            if (!await _userManager.CheckPasswordAsync(user, request.Password))
                return await Result<LoginResponse>.FailAsync($"Invalid password");

            var userRoles = await _userManager.GetRolesAsync(user);
            var authClaims = new List<Claim>
            {
               new Claim(ClaimTypes.Name, user.UserName!),
               new Claim(CustomClaimTypes.OrganizationId, user.OrganizationId.ToString()),
               new Claim(CustomClaimTypes.OrganizationName, user.Organization.FullName), 
               new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole)) ;
            }
            string token = GenerateToken(authClaims);

            var responseData = new LoginResponse(token, user.UserName!, userRoles);

            return await Result<LoginResponse>.SuccessAsync(responseData, "Success!");
        }

        public async Task<Result<UpdatePasswordResponse>> UpdatePassword(UpdatePasswordRequest request)
        {
            var userResult = await _applicationUserService.GetCurrentUser();
            if (!userResult.Succeeded)
            {
                return await Result<UpdatePasswordResponse>.FailAsync($"{userResult.Messages}");
            }

            var flag1 = await _userManager.CheckPasswordAsync(userResult.Data, request.OldPassword);
            var flag2 = await _userManager.CheckPasswordAsync(userResult.Data, request.NewPassword);

            if (!flag1)
            {
                return await Result<UpdatePasswordResponse>.FailAsync(
                    new UpdatePasswordResponse(PasswordUpdate.OldPasswordNotConfirmed, 
                    PasswordUpdateMessage.OldPasswordNotConfirmed));
            }

            if(flag2)
            {
                return await Result<UpdatePasswordResponse>.FailAsync(
                    new UpdatePasswordResponse(PasswordUpdate.NewAndOldPasswordIdentical, 
                    PasswordUpdateMessage.NewAndOldPasswordIdentical));
            }

            var updatePasswordResult = await _userManager.ChangePasswordAsync(userResult.Data, request.OldPassword, request.NewPassword);

            if(!updatePasswordResult.Succeeded)
            {
                return await Result<UpdatePasswordResponse>.FailAsync(
                    new UpdatePasswordResponse(PasswordUpdate.PasswordUpdateFailed,
                    PasswordUpdateMessage.PasswordUpdateFailed));
            }

            return await Result<UpdatePasswordResponse>.SuccessAsync(
                new UpdatePasswordResponse(PasswordUpdate.PasswordUpdateSucceded,
                PasswordUpdateMessage.PasswordUpdateSuccceded));
        }

        #region private methods
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = _configuration["JWT:ValidIssuer"],
                Audience = _configuration["JWT:ValidAudience"],
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(claims)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
