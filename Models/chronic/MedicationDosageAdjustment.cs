using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CodeMed.Models.chronic
{
    public class MedicationDosageAdjustment
    {
        [Key]
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public string? MedicationName { get; set; }
        public string? Dose { get; set; }
        public string? RoutesOfAdministration { get; set; }
        public string? AdjustmentReason { get; set; }
        public string? NewMedication { get; set; }
        public string? ProposedDose { get; set; }
        public string? ProposedRouteOfAdministration { get; set; }
        public string? Warning { get; set; }
        public string? SpecialInstructions { get; set; }
        public string? ContactNumber { get; set; }
        public string? EmailAddress { get; set; }
        public DateTime Date { get; set; }
    }
}
