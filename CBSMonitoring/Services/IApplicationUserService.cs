using CBSMonitoring.Models;
using ERPBlazor.Shared.Wrappers;
using System.Security.Claims;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Services
{
    public interface IApplicationUserService
    {
        Task<Result<IEnumerable<User>>> GetAllUsers();
        Task<Result<ApplicationUser>> GetCurrentUser();
        Task<Result<bool>> IsUserAuthorizedForThisInfo(int id);
        Task<Result<string>> GetCurrentUserClaim(string claim);
        Task<Result<IEnumerable<string?>>> GetUserRoles();
        Task<Result<string>> ChangeUserStatus(string userName);
        Task<Result<string>> UpdateUserInfo(UserUpdateRequest request);
        Task<Result<string>> UpdateSelfInfo(UserSelfUpdateRequest request);
    }
}
