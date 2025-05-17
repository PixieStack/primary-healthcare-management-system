using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeMed.Models.chronic
{
    public class MedicationPrescription
    {
        [Key]
        public int PrescriptionID { get; set; }
        [Required(ErrorMessage = "Doctor is required")]
        public string? Doctor { get; set; }
        public string? Patient { get; set; }

        [Required(ErrorMessage = "Chronic Condition is required")]
        public string? ChronicCondition { get; set; }

        [Required(ErrorMessage = "Medication Name is required")]
        public string? MedicationName { get; set; }

        [Required(ErrorMessage = "Dose is required")]
        public string? Dose { get; set; }

        [Required(ErrorMessage = "Route of Administration is required")]
        public string? RoutesOfAdministration { get; set; }

        [Required(ErrorMessage = "Warning is required")]
        public string? Warning { get; set; }

        [Required(ErrorMessage = "Special Instructions are required")]
        public string? SpecialInstructions { get; set; }

        [Required(ErrorMessage = "Contact Number is required")]
        public string? ContactNumber { get; set; }

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? EmailAddress { get; set; }

        [Required(ErrorMessage = "Prescription Date is required")]
        [DataType(DataType.Date)]
        public DateTime PrescriptionDate { get; set; }
    }
}
