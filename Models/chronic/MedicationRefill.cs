using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeMed.Models.chronic
{
    public class MedicationRefill
    {
        [Key]
        public int MedicationRefillID { get; set; }
        [Required]
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        [Required]
        public string? ContactNumber { get; set; }
        [Required]
        public string? PhysicalAddress { get; set; }
        [Required]
        public string? MedicationName { get; set; }
        [Required]
        public string? Dose { get; set; }
        [Required]
        public string? RoutesOfAdministration { get; set; }
        [Required]
        public string? DeliveryOptions { get; set; }
        [Required]
        public DateTime RefillDate { get; set; }
    }
}
