using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.vaccines
{
    public class VaccinationReportReactions
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? SelectedVaccine { get; set; }
        public string? SelectedImmunization { get; set; }
        public string? Reactions { get; set; }
        public DateTime ReactionDate { get; set; }
    }
}
