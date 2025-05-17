// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using CodeMed.Areas.Identity.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeMed.Areas.Identity.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<CodeMedUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<CodeMedUser> signInManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                var user = await _signInManager.UserManager.FindByEmailAsync(Input.Email);

                if (user != null)
                {
                    var citizenship = user.Citizenship;

                    if (citizenship == "South African Citizen")
                    {
                        // Fetch ID Number
                        HttpContext.Session.SetString("ID_Number", user.ID_Number.ToString());
                    }
                    else if (citizenship == "Non South African Citizen")
                    {
                        // Fetch Passport Number
                        HttpContext.Session.SetString("Passport_Number", user.Passport_Number);
                    }

                    // Store other user information in session
                    HttpContext.Session.SetString("Citizenship", user.Citizenship);
                    HttpContext.Session.SetString("Id", user.Id);
                    HttpContext.Session.SetString("FirstName", user.FirstName);
                    HttpContext.Session.SetString("LastName", user.LastName);
                    HttpContext.Session.SetString("Title", user.Title);
                    HttpContext.Session.SetString("Street_Address", user.Street_Address);
                    HttpContext.Session.SetString("Surburb", user.Surburb);
                    HttpContext.Session.SetString("City", user.City);
                    HttpContext.Session.SetString("Province", user.Province);
                    HttpContext.Session.SetString("Postal_Code", user.Postal_Code);
                    HttpContext.Session.SetString("Phone_Number", user.Phone_Number);
                    HttpContext.Session.SetString("Email", user.Email);
                    HttpContext.Session.SetString("Role", user.Role);
                    if (user.Role == "PHC Worker")
                    {
                        HttpContext.Session.SetString("PHC_Role", user.PHC_Role);
                    }

                    var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                    if (user.Role == "Administrator")
                    {
                        // Redirect to the Administrator's action
                        return RedirectToAction("PrenatalIndex", "Administrators");
                    }
                    else
                    {
                        // For other roles, redirect to the "LoggedIn" page
                        return RedirectToAction("Index", "LoggedIn");
                    }
                    if (result.RequiresTwoFactor)
                    {
                        return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                    }
                    if (result.IsLockedOut)
                    {
                        _logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            return Page();
        }

    }

}
