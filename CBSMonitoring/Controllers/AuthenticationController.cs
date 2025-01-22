using CBSMonitoring.Constants;
using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Models;
using CBSMonitoring.Services;
using ERPBlazor.Shared.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Serilog.Parsing;
using System.IdentityModel.Tokens.Jwt;
using static CBSMonitoring.DTOs.Requests;
using static CBSMonitoring.DTOs.Responses;

namespace CBSMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Login([FromBody]LoginRequest request, [FromServices] IMemoryCache memoryCache)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid payload");
            
            var result = await _authService.Login(request, memoryCache);
            
            return StatusCode(result.StatusCode, result);

        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            var result = await _authService.Logout(request.Token);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost]
        [Route("registeration")]
        [Authorize(Roles = UserRoles.Admin)]
        [Authorize(Policy = "RequirePasswordChange")]
        public async Task<IActionResult> Register([FromBody]RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value?.Errors.Select(e => e.ErrorMessage).ToArray()
                );

                return BadRequest(errors);
            }
                

            var result = await _authService.Registeration(request);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("send-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> SendOtpEmail(string username, string tempToken)
        {
            var result = await _authService.SendOtpEmail(username, tempToken);
            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("verify-otp")]
        [AllowAnonymous]
        public async Task<IActionResult> VerifyOtp(OtpVerificationRequest otpVerificationRequest)
        {
            var result = await _authService.VerifyOtp(otpVerificationRequest);
            return StatusCode(result.StatusCode, result);
        }


        [HttpPost]
        [Route("updatePassword")]
        [Authorize]
        public async Task<IActionResult> UpdatePassword(UpdatePasswordRequest request)
        {
            var result = await _authService.UpdatePassword(request);

            return StatusCode(result.StatusCode, result);
        }
       
    }
}
