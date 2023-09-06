using CBSMonitoring.Data;
using CBSMonitoring.DTOs;
using CBSMonitoring.Services;
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
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly AppDbContext _context;
        private readonly TokenService _tokenService;
        public AuthController(UserManager<IdentityUser> userManager, TokenService tokenService, AppDbContext context)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _context = context;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _userManager.CreateAsync(
                new IdentityUser { UserName = request.UserName, Email = request.Email },
                request.Password
            );
            if (result.Succeeded)
            {
                var response = new Responses.RegistrationResponse(request.UserName, request.Email, "");
                return CreatedAtAction(nameof(Register), new { email = response.Email }, response);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate([FromBody] AuthRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var managedUser = await _userManager.FindByEmailAsync(request.Email);
            if (managedUser == null)
            {
                return BadRequest("Bad credentials");
            }
            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, request.Password);
            if (!isPasswordValid)
            {
                return BadRequest("Bad credentials");
            }
            var userInDb = _context.Users.FirstOrDefault(u => u.Email == request.Email);
            if (userInDb is null)
                return Unauthorized();
            var accessToken = _tokenService.CreateToken(userInDb);
            await _context.SaveChangesAsync();
            return Ok(new AuthResponse(userInDb.UserName, userInDb.Email, accessToken));
            
        }
    }
}
