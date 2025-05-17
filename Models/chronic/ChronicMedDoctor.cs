using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeMed.Models.chronic
{
    public class ChronicMedDoctor
    {
        [Key]
        public int DoctorID { get; set; }
        [DisplayName("National Provider Identifier")]
        [Required]
        public int NPI { get; set; }
        [DisplayName("First Name")]
        [Required]
        public string? FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [DisplayName("Medical Specialty")]
        [Required]
        public string? MedicalSpecialty { get; set; }
        [Required]
        public string? Hospital { get; set; }
        [DisplayName("Work Experience")]
        [Required]
        public int? WorkExperience { get; set; }
        [DisplayName("Phone Number")]
        [Required]
        public string? PhoneNumber { get; set; }
        [DisplayName("Email Address")]
        [Required]
        public string? EmailAddress { get; set; }
        [DisplayName("Physical Address")]
        [Required]
        public string? PhysicalAddress { get; set; }

    }
}
