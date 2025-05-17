using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.vaccines
{
    public class VaccinationAdminister
    {
        [Key]
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public int PatientAge { get; set; }
        public string? VaccineName { get; set; }
        public DateTime VaccineDate { get; set; }
        public int DoseNumber { get; set; }
        public string? AdministrationSite { get; set; }
        public string? SideEffects { get; set; }
    }
}
