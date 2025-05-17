using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeMed.Models.chronic
{
    public class ChronicMedPatient
    {
        [Key]
        public int? PatientID { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string? LastName { get; set; }
        [DisplayName("Date Of Birth")]
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string? Gender { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }
        [DisplayName("Email Address")]
        [Required]
        public string? EmailAddress { get; set; }
        [DisplayName("Physical Address")]
        [Required]
        public string? PhysicalAddress { get; set; }
        [DisplayName("Name of Emergency Contact Person")]
        [Required]
        public string? EmergencyContactPerson { get; set; }
        [DisplayName("Relationship to patient")]
        [Required]
        public string? Relationship { get; set; }
        [DisplayName("Emergency Contact Phone Number")]
        [Required]
        public string? EmergencyContactNumber { get; set; }
    }
}
