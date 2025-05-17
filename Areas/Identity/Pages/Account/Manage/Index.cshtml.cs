using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using CodeMed.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CodeMed.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<CodeMedUser> _userManager;
        private readonly SignInManager<CodeMedUser> _signInManager;

        public IndexModel(
            UserManager<CodeMedUser> userManager,
            SignInManager<CodeMedUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string? Phone_Number { get; set; }

            [Display(Name = "Last Name")]
            public string? LastName { get; set; }

            [Display(Name = "Street Address")]
            public string? Street_Address { get; set; }

            [Display(Name = "Surburb")]
            public string? Surburb { get; set; }

            [Display(Name = "City")]
            public string? City { get; set; }

            [Display(Name = "Province")]
            public string? Province { get; set; }

            [Display(Name = "Postal Code")]
            public string? Postal_Code { get; set; }

            [Display(Name = "Next of Kin Name")]
            public string? NextOfKinName { get; set; }

            [Display(Name = "Next of Kin Relationship")]
            public string? NextOfKinRelationship { get; set; }

            [Display(Name = "Next of Kin Phone")]
            [Phone]
            public string? NextOfKinPhone { get; set; }

            [Display(Name = "Next of Kin Email")]
            [EmailAddress]
            public string? NextOfKinEmail { get; set; }
        }

        private async Task LoadAsync(CodeMedUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            var lastName = user.LastName; // Add similar lines for other properties
            var Street_Address = user.LastName;
            var Surburb = user.LastName;
            var City = user.LastName;
            var Province = user.LastName;
            var Postal_Code = user.LastName;
            var NextOfKinName = user.LastName;
            var NextOfKinRelationship = user.LastName;
            var NextOfKinPhone = user.LastName;
            var NextOfKinEmail = user.LastName;

            Username = userName;

            Input = new InputModel
            {
                Phone_Number = phoneNumber,
                LastName = lastName, 
                Street_Address = user.Street_Address,
                Surburb = user.Surburb,
                City = user.City,
                Province = user.Province,
                Postal_Code = user.Postal_Code,
                NextOfKinName = user.NextOfKinName,
                NextOfKinRelationship = user.NextOfKinRelationship,
                NextOfKinPhone = user.NextOfKinPhone,
                NextOfKinEmail = user.NextOfKinEmail
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.Phone_Number != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.Phone_Number);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            user.LastName = Input.LastName;
            user.Street_Address = Input.Street_Address;
            user.Surburb = Input.Surburb;
            user.City = Input.City;
            user.Province = Input.Province;
            user.Postal_Code = Input.Postal_Code;
            user.NextOfKinName = Input.NextOfKinName;
            user.NextOfKinRelationship = Input.NextOfKinRelationship;
            user.NextOfKinPhone = Input.NextOfKinPhone;
            user.NextOfKinEmail = Input.NextOfKinEmail;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
            {
                StatusMessage = "Unexpected error when trying to update profile.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
