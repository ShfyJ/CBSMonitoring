using CBSMonitoring.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CBSMonitoring.Webframework
{
    public class AuthorizeFirstLoginAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AuthorizeFirstLoginAttribute(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var user = await _userManager.GetUserAsync(context.HttpContext.User);

            if (user != null && user.IsFirstLogin)
            {
                // If user is in their first login, deny access
                context.Result = new ForbidResult();
            }
        }
    }
}
