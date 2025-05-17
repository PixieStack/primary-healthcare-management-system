using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeMed.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CodeMed.Areas.Identity.Pages.Account.Manage
{
    public class DownloadPersonalDataModel : PageModel
    {
        private readonly UserManager<CodeMedUser> _userManager;
        private readonly ILogger<DownloadPersonalDataModel> _logger;

        public DownloadPersonalDataModel(
            UserManager<CodeMedUser> userManager,
            ILogger<DownloadPersonalDataModel> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

            // Generate the plain text report
            var personalData = GeneratePlainTextReport(user);

            // Set the response headers for downloading a .txt file
            Response.Headers.Add("Content-Disposition", "attachment; filename=PersonalData.txt");

            // Convert the report to bytes and return as a file
            var reportBytes = Encoding.UTF8.GetBytes(personalData);
            return new FileContentResult(reportBytes, "text/plain");
        }

        private string GeneratePlainTextReport(CodeMedUser user)
        {
            // Create a StringBuilder to build the report content
            var report = new StringBuilder();

            // Add a line of equal signs under the "Personal Data Report" title
            report.AppendLine("Personal Data Report");
            report.AppendLine("========================");
            report.AppendLine();
            // Append user's personal data to the report with proper formatting
            report.AppendLine("Personal Details");
            report.AppendLine("========================");
            report.AppendLine($"User ID:                    {user.Id}");
            report.AppendLine($"Citizenship:                {user.Citizenship}");
            report.AppendLine($"ID Number:                  {user.ID_Number}");
            report.AppendLine($"Passport Number:            {user.Passport_Number}");
            report.AppendLine($"Title:                      {user.Title}");
            report.AppendLine($"Full Name:                  {user.FirstName} {user.LastName}");
            report.AppendLine($"Gender:                     {user.Gender}");
            report.AppendLine();
            report.AppendLine("Contact Details");
            report.AppendLine("========================");
            report.AppendLine($"Email:                      {user.Email}");
            report.AppendLine($"Phone Number:               {user.Phone_Number}");
            report.AppendLine();
            report.AppendLine("Home Address");
            report.AppendLine("========================");
            report.AppendLine($"Street Address:             {user.Street_Address}");
            report.AppendLine($"Suburb:                     {user.Surburb}");
            report.AppendLine($"City:                       {user.City}");
            report.AppendLine($"Province:                   {user.Province}");
            report.AppendLine($"Postal Code:                {user.Postal_Code}");
            report.AppendLine();
            report.AppendLine("Occupational Details");
            report.AppendLine("========================");
            report.AppendLine($"Role:                       {user.Role}");
            report.AppendLine($"PHC Role:                   {user.PHC_Role}");
            report.AppendLine($"PHC License Number:         {user.PHC_License_Number}");
            report.AppendLine($"Occupation:                 {user.Occupation}");
            report.AppendLine();
            report.AppendLine("Next Of Kin Details");
            report.AppendLine("========================");
            report.AppendLine($"Next of Kin Name:           {user.NextOfKinName}");
            report.AppendLine($"Next of Kin Relationship:   {user.NextOfKinRelationship}");
            report.AppendLine($"Next of Kin Phone:          {user.NextOfKinPhone}");
            report.AppendLine($"Next of Kin Email:          {user.NextOfKinEmail}");

            // Return the report as a plain text string
            return report.ToString();
        }

    }
}
