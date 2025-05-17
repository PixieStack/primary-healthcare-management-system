// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using CodeMed.Areas.Identity.Data;

namespace CodeMed.Areas.Identity.Pages.Account
{
	public class RegisterModel : PageModel
	{
		private readonly SignInManager<CodeMedUser> _signInManager;
		private readonly UserManager<CodeMedUser> _userManager;
		private readonly IUserStore<CodeMedUser> _userStore;
		private readonly IUserEmailStore<CodeMedUser> _emailStore;
		private readonly ILogger<RegisterModel> _logger;
		private readonly IEmailSender _emailSender;

		public RegisterModel(
			UserManager<CodeMedUser> userManager,
			IUserStore<CodeMedUser> userStore,
			SignInManager<CodeMedUser> signInManager,
			ILogger<RegisterModel> logger,
			IEmailSender emailSender)
		{
			_userManager = userManager;
			_userStore = userStore;
			_emailStore = GetEmailStore();
			_signInManager = signInManager;
			_logger = logger;
			_emailSender = emailSender;
		}

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		[BindProperty]
		public InputModel Input { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public string ReturnUrl { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public IList<AuthenticationScheme> ExternalLogins { get; set; }

		/// <summary>
		///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
		///     directly from your code. This API may change or be removed in future releases.
		/// </summary>
		public class InputModel
		{
			[PersonalData]
			public long ID_Number { get; set; }

			[PersonalData]
			public string Passport_Number { get; set; }

			[PersonalData]
			public string Citizenship { get; set; }

			[Required(ErrorMessage = "Please Enter your title!")]
			[PersonalData]
			public string Title { get; set; }

			[Required(ErrorMessage = "Please Enter your name!")]
			[PersonalData]
			public string FirstName { get; set; }

			[Required(ErrorMessage = "Please Enter your surname!")]
			[PersonalData]
			public string LastName { get; set; }

			[Required(ErrorMessage = "Please Enter your home address!")]
			[PersonalData]
			public string Street_Address { get; set; }

			[Required(ErrorMessage = "Please Enter your home address!")]
			[PersonalData]
			public string Surburb { get; set; }

			[Required(ErrorMessage = "Please Enter your home address!")]
			[PersonalData]
			public string City { get; set; }

			[Required(ErrorMessage = "Please Enter your home address!")]
			[PersonalData]
			public string Province { get; set; }

			[Required(ErrorMessage = "Please Enter your home address!")]
			[PersonalData]
			public string Postal_Code { get; set; }

			[Required(ErrorMessage = "Please Enter your phone number!")]
			[PersonalData]
			public string Phone_Number { get; set; }

			[Required(ErrorMessage = "Please Enter your gender!")]
			[PersonalData]
			public string Gender { get; set; }

			[Required(ErrorMessage = "Please Enter your role!")]
			[PersonalData]
			public string Role { get; set; }

			[PersonalData]
			public string PHC_Role { get; set; }

			[PersonalData]
			public string PHC_License_Number { get; set; }

			[Required(ErrorMessage = "Please Enter your occupation!")]
			[PersonalData]
			public string Occupation { get; set; }

			[Required(ErrorMessage = "Please Enter your next of kin name!")]
			[PersonalData]
			public string NextOfKinName { get; set; }

			[Required(ErrorMessage = "Please Enter your next of kin name!")]
			[PersonalData]
			public string NextOfKinRelationship { get; set; }

			[Required(ErrorMessage = "Please Enter your next of kin phone number!")]
			[PersonalData]
			public string NextOfKinPhone { get; set; }

			[Required(ErrorMessage = "Please Enter your next of kin phone email address!")]
			[PersonalData]
			public string NextOfKinEmail { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[EmailAddress]
			[Display(Name = "Email")]
			public string Email { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[Required]
			[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
			[DataType(DataType.Password)]
			[Display(Name = "Password")]
			public string Password { get; set; }

			/// <summary>
			///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
			///     directly from your code. This API may change or be removed in future releases.
			/// </summary>
			[DataType(DataType.Password)]
			[Display(Name = "Confirm password")]
			[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
			public string ConfirmPassword { get; set; }
		}


		public async Task OnGetAsync(string returnUrl = null)
		{
			ReturnUrl = returnUrl;
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
		}

		public async Task<IActionResult> OnPostAsync(string returnUrl = null)
		{
			returnUrl ??= Url.Content("~/");
			ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
			if (ModelState.IsValid)
			{
				var user = CreateUser();
				user.ID_Number = Input.ID_Number;
				user.Passport_Number = Input.Passport_Number;
				user.Citizenship = Input.Citizenship;
				user.FirstName = Input.FirstName;
				user.Title = Input.Title;
				user.LastName = Input.LastName;
				user.Street_Address = Input.Street_Address;
				user.Surburb = Input.City;
				user.City = Input.Street_Address;
				user.Province = Input.Province;
				user.Postal_Code = Input.Postal_Code;
				user.Phone_Number = Input.Phone_Number;
				user.Gender = Input.Gender;
				user.Role = Input.Role;
				user.PHC_Role = Input.PHC_Role;
				user.PHC_License_Number = Input.PHC_License_Number;
				user.Occupation = Input.Occupation;
				user.NextOfKinName = Input.NextOfKinName;
				user.NextOfKinRelationship = Input.NextOfKinRelationship;
				user.NextOfKinPhone = Input.NextOfKinPhone;
				user.NextOfKinEmail = Input.NextOfKinEmail;

				await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
				await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
				var result = await _userManager.CreateAsync(user, Input.Password);

				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					var userId = await _userManager.GetUserIdAsync(user);
					var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
					code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
					var callbackUrl = Url.Page(
						"/Account/ConfirmEmail",
						pageHandler: null,
						values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
						protocol: Request.Scheme);

					var userTitle = user.Title; // Assuming the user's first name is stored in a property called FirstName
					var userLastName = user.LastName;
					await SendEmailAsync(Input.Email, "Confirm Your Email",
	$"Dear {userTitle} {userLastName},<br><br>" +
	"We hope this email finds you well. Welcome to CodeMed, your trusted partner in maintaining optimal health and wellness. We're excited that you've chosen us as your primary health care provider. To ensure the security of your account and to provide you with the best possible service, we kindly ask you to confirm your email address.<br><br>" +
	"Please follow the simple steps below to confirm your email address:<br><br>" +
	$"<strong><a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>Click here to confirm your email address</a></strong><br><br>" +
	"By confirming your email address, you'll have access to a range of valuable features, including appointment scheduling, health records, prescription refills, and personalized health tips.<br><br>" +
	"At CodeMed, we prioritize the confidentiality and security of your personal information. Rest assured that your email address will be used exclusively for communication regarding your health care and will never be shared with third parties without your consent.<br><br>" +
	"If you encounter any issues during the confirmation process or have any questions about CodeMed's services, please don't hesitate to reach out to our dedicated support team at codemed.group.corp@outlook.com or +27 78 413 8225.<br><br>" +
	"Thank you for choosing CodeMed as your primary health care system. We look forward to providing you with exceptional care and support on your wellness journey.<br><br>" +
	"Best regards,<br><br>" +
	"Management<br>" +
	"CodeMed Primary Health Care System<br>" +
	"codemed.group.corp@outlook.com");

					if (_userManager.Options.SignIn.RequireConfirmedAccount)
					{
						return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
					}
					else
					{
						await _signInManager.SignInAsync(user, isPersistent: false);
						return LocalRedirect(returnUrl);
					}
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return Page();
		}

		private async Task<bool> SendEmailAsync(string email, string subject, string confirmLink)
		{
			try
			{
                MailMessage message = new MailMessage();
                SmtpClient smtpClient = new SmtpClient();

                message.From = new MailAddress("CodeMed.Group.Corp@outlook.com"); // Set the 'From' email address

                message.To.Add(email);
                message.Subject = subject;
                message.IsBodyHtml = true;
                message.Body = confirmLink;

                smtpClient.Port = 587; // Set the port to 587
                smtpClient.Host = "smtp.office365.com";

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("CodeMed.Group.Corp@outlook.com", "Tt@19990423(eden!)"); // Replace with actual credentials
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Send(message);
                return true;
            }
			catch (Exception)
			{
				return false;
			}
		}

		private CodeMedUser CreateUser()
		{
			try
			{
				return Activator.CreateInstance<CodeMedUser>();
			}
			catch
			{
				throw new InvalidOperationException($"Can't create an instance of '{nameof(CodeMedUser)}'. " +
					$"Ensure that '{nameof(CodeMedUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
					$"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
			}
		}

		private IUserEmailStore<CodeMedUser> GetEmailStore()
		{
			if (!_userManager.SupportsUserEmail)
			{
				throw new NotSupportedException("The default UI requires a user store with email support.");
			}
			return (IUserEmailStore<CodeMedUser>)_userStore;
		}
	}
}
