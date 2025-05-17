using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.vaccines
{
    public class VaccinationTravelMedicine
    {
        [Key]
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public string? Destination { get; set; }

        public string? MMR { get; set; }

        public string? DTaP { get; set; }

        public string? HepatitisA { get; set; }

        public string? HepatitisB { get; set; }

        public string? Travel_Specific { get; set; }

        public string? Health_Concerns { get; set; }
    }
}
