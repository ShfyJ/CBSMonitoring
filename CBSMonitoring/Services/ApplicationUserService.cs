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
                return await Result<bool>.FailAsync("Failed. Check for the request and try again!");
            }

            if (userRole == UserRoles.Admin || int.TryParse(organizationId, out var orgId) && orgId == id)
            {
                return await Result<bool>.SuccessAsync(true);
            }
            
            return await Result<bool>.SuccessAsync(false,"You are not authorized for this info");

        }

        public async Task<Result<string>> GetCurrentUserClaim(string claim)
        {
            return await Task.FromResult(currentUserPrincipal?.FindFirstValue(claim))
                .ContinueWith(task =>
                {
                    var claimValue = task.Result;
                    return claimValue != null
                        ? Result<string>.Success(claimValue, "Success!")
                        : Result<string>.Fail("Failed to get the claim");
                });
        }

        public async Task<Result<IEnumerable<string?>>> GetUserRoles()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();

            return await Result<IEnumerable<string?>>.SuccessAsync(roles);
        }

        public async Task<Result<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _userManager.Users
                .Include(u => u.Organization)
                .Select(u => new User(u.UserName, u.Email, u.FullName, u.Organization.FullName, u.Position, u.PhoneNumber))
                .ToListAsync();

            var task = Task.Delay(5000);
            task.Wait();

            return await Result<IEnumerable<User>>.SuccessAsync(users);

        }

        public async Task<Result<ApplicationUser>> GetCurrentUser()
        {
            var currentUserName = currentUserPrincipal?.FindFirstValue(ClaimTypes.Name);

            if (currentUserName == null)
            {
                return await Result<ApplicationUser>.FailAsync($"No {ClaimTypes.Name} Found!");
            }

            var user = await _userManager.FindByNameAsync(currentUserName);
            if(user == null)
            {
                return await Result<ApplicationUser>.FailAsync($"No User Found!");
            }
            
            return await Result<ApplicationUser>.SuccessAsync(user);
        }

        public async Task<Result<string>> ChangeUserStatus(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                return await Result<string>.FailAsync($"No user found with this user name = {userName}");
            }

            user.LockoutEnabled = true;
            user.LockoutEnd = DateTime.Now.AddYears(1000);
            user.IsActive = false;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
                return await Result<string>.FailAsync($"Failed : {updateResult.Errors}");

            return await Result<string>.SuccessAsync($"Success");
        }

        public async Task<Result<string>> UpdateUserInfo(UserUpdateRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if(user == null)
            {
                return await Result<string>.FailAsync($"No user found with user name = {request.UserName}");
            }

            try
            {
                _mapper.Map(request, user);
                await _userManager.UpdateAsync(user);

                return await Result<string>.SuccessAsync($"Success");
            }
            catch(Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }
           
        }

        public async Task<Result<string>> UpdateSelfInfo(UserSelfUpdateRequest request)
        {
            var userResult = await GetCurrentUser();

            if (!userResult.Succeeded)
            {
                return await Result<string>.FailAsync($"{userResult.Messages}");
            }

            try
            {
                _mapper.Map(request, userResult.Data);
                await _userManager.UpdateAsync(userResult.Data);

                return await Result<string>.SuccessAsync($"Success");
            }
            catch (Exception ex)
            {
                return await Result<string>.FailAsync(ex.Message);
            }

        }
    }
}
