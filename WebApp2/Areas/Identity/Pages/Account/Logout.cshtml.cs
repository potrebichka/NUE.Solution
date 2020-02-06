using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using WebApp2.Models;
using System.Security.Claims;

namespace WebApp2.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<LogoutModel> _logger;

        public LogoutModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // var currentUser = await _userManager.FindByIdAsync(userId);
            // Claim claim = User.Claims.Where(x => x.Type == "urn:google:picture").FirstOrDefault();
            // if (claim != null)
            // {
            //     IdentityResult result = await _userManager.RemoveClaimAsync(currentUser, claim);
            // }
            // claim = User.Claims.Where(x => x.Type == "Picture").FirstOrDefault();
            // if (claim != null)
            // {
            //     IdentityResult result = await _userManager.RemoveClaimAsync(currentUser, claim);
            // }

            // [optional] remove claims from claims table dbo.AspNetUserClaims, if not needed
            // var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            // var currentUser = await _userManager.FindByIdAsync(userId);
            // var userClaims = await _userManager.GetClaimsAsync(currentUser);
            // if (userClaims.Any())
            // {
            //     foreach (var item in userClaims)
            //     {
            //         await _userManager.RemoveClaimAsync(currentUser, item);
            //     }
            // }

            await _signInManager.SignOutAsync();
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Page();
            }
        }
    }
}