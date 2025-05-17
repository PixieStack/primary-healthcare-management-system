using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models
{
	public class PrenatalUpdate
	{
		public long? ID_Number { get; set; }

		public string? Passport_Number { get; set; }

		[Required(ErrorMessage = "Please select citizenship")]
		[PersonalData]
		public string? Citizenship { get; set; }

		[Required(ErrorMessage = "Please Enter your name!")]
		[PersonalData]
		public string? FirstName { get; set; }

		[Required(ErrorMessage = "Please Enter your surname!")]
		[PersonalData]
		public string? LastName { get; set; }

		[Required(ErrorMessage = "Please Enter your home address!")]
		[PersonalData]
		public string? Home_Address { get; set; }

		[Required(ErrorMessage = "Please Enter your phone number!")]
		[PersonalData]
		public long? Phone_Number { get; set; }

		[Required(ErrorMessage = "Please Enter your gender!")]
		[PersonalData]
		public string? Gender { get; set; }

		[Required(ErrorMessage = "Please Enter your role!")]
		[PersonalData]
		public string? Role { get; set; }

		[PersonalData]
		public string? PHC_Role { get; set; }

		[PersonalData]
		public string? PHC_License_Number { get; set; }

		[Required(ErrorMessage = "Please Enter your occupation!")]
		[PersonalData]
		public string? Occupation { get; set; }

		[Required(ErrorMessage = "Please Enter your next of kin name!")]
		[PersonalData]
		public string? NextOfKinName { get; set; }

		[Required(ErrorMessage = "Please Enter your next of kin phone number!")]
		[PersonalData]
		public string? NextOfKinPhone { get; set; }

		[Required(ErrorMessage = "Please Enter your next of kin phone email address!")]
		[PersonalData]
		public string? NextOfKinEmail { get; set; }
	}
}
