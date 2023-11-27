using CBSMonitoring.Constants;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using CBSMonitoring.DTOs;
using System.Runtime.CompilerServices;
using CBSMonitoring.Models;
using static CBSMonitoring.DTOs.Responses;
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using static CBSMonitoring.DTOs.Requests;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CBSMonitoring.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ClaimsPrincipal? currentUserPrincipal;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        public ApplicationUserService(IHttpContextAccessor contextAccessor, 
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IMapper mapper)
        {
            _roleManager = roleManager;
            currentUserPrincipal = contextAccessor.HttpContext?.User;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<Result<bool>> IsUserAuthorizedForThisInfo(int id)
        {
            var userRole = currentUserPrincipal?.FindFirst(ClaimTypes.Role)?.Value;
            var organizationId = currentUserPrincipal?.FindFirst(CustomClaimTypes.OrganizationId)?.Value;

            if (string.IsNullOrEmpty(userRole) || string.IsNullOrEmpty(organizationId))
            {
                return await Result<bool>.FailAsync("Неуспешно: Проверьте наличие запроса и повторите попытку!");
            }

            if (userRole == UserRoles.Admin || int.TryParse(organizationId, out var orgId) && orgId == id)
            {
                return await Result<bool>.SuccessAsync(true);
            }
            
            return await Result<bool>.SuccessAsync(false, "У вас нет прав на эту информацию");

        }

        public async Task<Result<string>> GetCurrentUserClaim(string claim)
        {
            return await Task.FromResult(currentUserPrincipal?.FindFirstValue(claim))
                .ContinueWith(task =>
                {
                    var claimValue = task.Result;
                    return claimValue != null
                        ? Result<string>.Success(claimValue, "Успешно!")
                        : Result<string>.Fail("Запрошенная информация недоступна");
                });
        }

        public async Task<Result<IEnumerable<string?>>> GetUserRoles()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            return await Result<IEnumerable<string?>>.SuccessAsync(roles);
        }

        public async Task<Result<IEnumerable<User>>> GetAllUsers()
        {
            var usersWithRoles = new List<User>();
            
            var users = await _userManager.Users
                .Include(u => u.Organization)
                .ToListAsync();

            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u); // Async call

                var user = new User(u.UserName, u.Email, u.IsActive, roles, u.FullName, 
                    u.Organization.FullName, u.OrganizationId, u.Position, u.PhoneNumber);

                usersWithRoles.Add(user);
            }

            //var task = Task.Delay(5000);
            //task.Wait();

            return await Result<IEnumerable<User>>.SuccessAsync(usersWithRoles);

        }

        public async Task<Result<ApplicationUser>> GetCurrentUser()
        {
            var currentUserName = currentUserPrincipal?.FindFirstValue(ClaimTypes.Name);

            if (currentUserName == null)
            {
                return await Result<ApplicationUser>.FailAsync($"'{ClaimTypes.Name}' не найдено!");
            }

            var user = await _userManager.FindByNameAsync(currentUserName);
            if(user == null)
            {
                return await Result<ApplicationUser>.FailAsync($"'{currentUserName}' пользователь не найден!");
            }
            
            return await Result<ApplicationUser>.SuccessAsync(user);
        }

        public async Task<Result<string>> ChangeUserStatus(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                return await Result<string>.FailAsync($"'{userName}' пользователь не найден!");
            }

            if(user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                user.LockoutEnd = DateTime.Now; 
                user.IsActive = false;
            }

            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
                user.IsActive = true;
            }

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                return await Result<string>.FailAsync($"Неуспешно: {String.Join(", ",updateResult.Errors)}");

            return await Result<string>.SuccessAsync($"Успешно!");
        }

        public async Task<Result<List<string?>>> UpdateUserInfo(UserUpdateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if(user == null)
            {
                return await Result<List<string?>>.FailAsync($"'{request.UserName}' пользователь не найден!");
            }

            var messages = new List<string?>();

            try
            {
                if(!request.Roles.IsNullOrEmpty()) 
                {
                    var currentRoles = await _userManager.GetRolesAsync(user);
                    var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);

                    if (removeResult.Succeeded)
                    {
                        messages.Add($"Старые роли удалены!");
                        var addResult = await _userManager.AddToRolesAsync(user, request.Roles!);
                        if (!addResult.Succeeded)
                        {                            
                            messages.Add($"Не удалось добавить новые роли: {String.Join(". ",addResult.Errors)}");
                            messages.Add(removeResult.Errors.ToString());
                        }
                    }

                    else
                    {
                        messages.Add($"Не удалось удалить старые роли: {String.Join(". ",removeResult.Errors)}");
                        messages.Add(removeResult.Errors.ToString());
                    }
                    
                }

                _mapper.Map(request, user);                
                await _userManager.UpdateAsync(user);

                messages.Add($"Информация о пользователе обновлена!");
                return await Result<List<string?>>.SuccessAsync(messages);
            }
            catch(Exception ex)
            {
                messages.Add(ex.Message);
                return await Result<List<string?>>.FailAsync(messages!);
            }
           
        }

        public async Task<Result<string>> UpdateSelfInfo(UserSelfUpdateRequest request)
        {
            var userResult = await GetCurrentUser();

            if (!userResult.Succeeded)
            {
                return await Result<string>.FailAsync($"Невозможно получить текущего пользователя: {String.Join(". ",userResult.Messages)}");
            }

            try
            {
                _mapper.Map(request, userResult.Data);
                await _userManager.UpdateAsync(userResult.Data);

                return await Result<string>.SuccessAsync($"Успешно!");
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync($"Не удалось обновить данные пользователя: {ex.Message}");
            }

        }
    }
}
