using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Doctor
{
    public class Prenatal_Obstetrician_Referral
    {
        public int? ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Referral_Date { get; set; }

        [Required]
        public string? Province { get; set; }

        [Required]
        public string? Hospital { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Clinic_Name { get; set; }

        [Required]
        public string? Symptoms { get; set; }

        [Required]
        public string? Comments { get; set; }
    }
}
