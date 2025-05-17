using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.chronic
{
    public class MedicationFeedback
    {
        [Key]
        public int? Id { get; set; }
        public string? Patient { get; set; }
        public string? MedicationName { get; set; }
        public string? Dose { get; set; }

        public DateTime Date { get; set; }

        public string? SideEffects { get; set; }
        public string? Effectiveness { get; set; }
    }
}
