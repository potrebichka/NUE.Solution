using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NUE.Models;
using Microsoft.AspNetCore.Authentication;

namespace NUE.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            ILogger<ExternalLoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string LoginProvider { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        #region snippet_OnGetCallbackAsync
        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, 
            string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new {ReturnUrl = returnUrl });
            }

            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, 
                info.ProviderKey, isPersistent: false, bypassTwoFactor : true);

            if (result.Succeeded)
            {
                
                var user = await _userManager.FindByLoginAsync(info.LoginProvider, 
                    info.ProviderKey);

                var props = new AuthenticationProperties();
                props.StoreTokens(info.AuthenticationTokens);

                await _signInManager.SignInAsync(user, props, info.LoginProvider);

                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", 
                    info.Principal.Identity.Name, info.LoginProvider);

                return LocalRedirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                return RedirectToPage("./Lockout");
            }
            else
            {
               
                ReturnUrl = returnUrl;
                LoginProvider = info.LoginProvider;

                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                    };
                }

                return Page();
            }
        }
        #endregion

        #region snippet_OnPostConfirmationAsync
        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
            {
                ErrorMessage = 
                    "Error loading external login information during confirmation.";

                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email, 
                    Email = Input.Email 
                };

                var result = await _userManager.CreateAsync(user);

                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user, info);

                    if (result.Succeeded)
                    {
                       
                        if (info.Principal.HasClaim(c => c.Type == ClaimTypes.GivenName))
                        {
                            await _userManager.AddClaimAsync(user, 
                                info.Principal.FindFirst(ClaimTypes.GivenName));
                        }

                        if (info.Principal.HasClaim(c => c.Type == "urn:google:locale"))
                        {
                            await _userManager.AddClaimAsync(user, 
                                info.Principal.FindFirst("urn:google:locale"));
                        }

                        if (info.Principal.HasClaim(c => c.Type == "urn:google:picture"))
                        {
                            await _userManager.AddClaimAsync(user, 
                                info.Principal.FindFirst("urn:google:picture"));
                        }

                        if (info.Principal.HasClaim(c => c.Type == "Picture"))
                        {
                            var claim = info.Principal.Claims.Where(x => x.Type == "Picture").FirstOrDefault();
                            await _userManager.AddClaimAsync(user, claim);
                        }

                                                if (info.Principal.HasClaim(c => c.Type == "profile-image-url"))
                        {
                            var claim = info.Principal.Claims.Where(x => x.Type == "profile-image-url").FirstOrDefault();
                            await _userManager.AddClaimAsync(user, claim);
                        }

                        if (info.Principal.HasClaim(c => c.Type == "twitter:name"))
                        {
                            var claim = info.Principal.Claims.Where(x => x.Type == "twitter:name").FirstOrDefault();
                            await _userManager.AddClaimAsync(user, claim);
                        }

                        if (info.Principal.HasClaim(c => c.Type == "twitter:token"))
                        {
                            var claim = info.Principal.Claims.Where(x => x.Type == "twitter:token").FirstOrDefault();
                            await _userManager.AddClaimAsync(user, claim);
                        }

                        if (info.Principal.HasClaim(c => c.Type == "twitter:id"))
                        {
                            var claim = info.Principal.Claims.Where(x => x.Type == "twitter:id").FirstOrDefault();
                            await _userManager.AddClaimAsync(user, claim);
                        }

                        var props = new AuthenticationProperties();
                        props.StoreTokens(info.AuthenticationTokens);
                        props.IsPersistent = true;

                        await _signInManager.SignInAsync(user, props);

                        _logger.LogInformation(
                            "User created an account using {Name} provider.", 
                            info.LoginProvider);

                        return LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            LoginProvider = info.LoginProvider;
            ReturnUrl = returnUrl;
            return Page();
        }
        #endregion
    }
}
