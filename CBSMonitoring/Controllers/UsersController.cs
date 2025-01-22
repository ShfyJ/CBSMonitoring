using CBSMonitoring.Constants;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static CBSMonitoring.DTOs.Requests;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "RequirePasswordChange")]
    public class UsersController : ControllerBase
    {
        private readonly IApplicationUserService _applicationUserService;
        public UsersController(IApplicationUserService applicationUserService)
        {
           _applicationUserService = applicationUserService;
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _applicationUserService.GetUserRoles();

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _applicationUserService.GetAllUsers();
            
            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPut("ChangeUserStatus")]
        public async Task<IActionResult> ChangeUserStatus(string userName)
        {
            var result = await _applicationUserService.ChangeUserStatus(userName);

            return StatusCode(result.StatusCode, result);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost("UpdateUserInfo")]
        public async Task<IActionResult> UpdateUserInfo(UserUpdateRequest request)
        {
            var result = await _applicationUserService.UpdateUserInfo(request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("UpdateSelfInfo")]
        public async Task<IActionResult> UpdateSelfInfo(UserSelfUpdateRequest request)
        {
            var result = await _applicationUserService.UpdateSelfInfo(request);

            return StatusCode(result.StatusCode, result);
        }
    }
}
