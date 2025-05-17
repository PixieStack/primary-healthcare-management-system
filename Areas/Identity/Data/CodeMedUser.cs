using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace CodeMed.Areas.Identity.Data;

// Add profile data for application users by adding properties to the CodeMedUser class
public class CodeMedUser : IdentityUser
{
	
	public long? ID_Number { get; set; }

    public string? Passport_Number { get; set; }

    [Required(ErrorMessage = "Please Enter your title!")]
    [PersonalData]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Please select citizenship")]
    [PersonalData]
    public string? Citizenship { get; set; }

    [Required(ErrorMessage = "Please Enter your name!")]
    [PersonalData]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please Enter your surname!")]
    [PersonalData]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please Enter your street address!")]
    [PersonalData]
    public string? Street_Address { get; set; }

	[Required(ErrorMessage = "Please Enter your surburb!")]
	[PersonalData]
	public string? Surburb { get; set; }

	[Required(ErrorMessage = "Please Enter your city!")]
	[PersonalData]
	public string? City { get; set; }

	[Required(ErrorMessage = "Please Enter province!")]
	[PersonalData]
	public string? Province { get; set; }

	[Required(ErrorMessage = "Please Enter your postal code!")]
	[PersonalData]
	public string? Postal_Code { get; set; }

	[Required(ErrorMessage = "Please Enter your phone number!")]
    [PersonalData]
    public string? Phone_Number { get; set; }

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

	[Required(ErrorMessage = "Please Enter your next of kin relationship!")]
	[PersonalData]
	public string? NextOfKinRelationship { get; set; }

	[Required(ErrorMessage = "Please Enter your next of kin phone number!")]
    [PersonalData]
    public string? NextOfKinPhone { get; set; }

    [Required(ErrorMessage = "Please Enter your next of kin phone email address!")]
    [PersonalData]
    public string? NextOfKinEmail { get; set; }
}

