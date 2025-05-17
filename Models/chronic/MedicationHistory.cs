using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.chronic
{
    public class MedicationHistory
    {
        [Key]
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }

        [Required(ErrorMessage = "Chronic Condition is required")]
        public string? ChronicCondition { get; set; }

        [Required(ErrorMessage = "Allergies is required")]
        public string? Allergies { get; set; }

        [Required(ErrorMessage = "Family History is required")]
        public string? FamilyHistory { get; set; }

        public string? MedicationName { get; set; }

        [Required(ErrorMessage = "Dose is required")]
        public string? Dose { get; set; }

        [Required(ErrorMessage = "Medication Reason is required")]
        public string? MedicationReason { get; set; }
    }
}
