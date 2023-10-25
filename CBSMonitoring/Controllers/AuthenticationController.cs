using CBSMonitoring.Constants;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(IAuthService authService, ILogger<AuthenticationController> logger)
        {
            _authService = authService;
            _logger = logger;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var result = await _authService.Login(request);
                if (!result.Succeeded)
                    return BadRequest(result.Messages);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        
        [HttpPost]
        [Route("registeration")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var result = await _authService.Registeration(request);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Messages);
                }
                return CreatedAtAction(nameof(Register), request);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("updatePassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            var result = await _authService.UpdatePassword(request);

            if(!result.Succeeded)
            { 
                return BadRequest(result); 
            }

            return Ok(result);
        }
       
    }
}
