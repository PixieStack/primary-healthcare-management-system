namespace CodeMed.Models.vaccines
{
    public class Vaccinations
    {
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? VaccineType { get; set; }
        public DateTime VaccinationDate { get; set; }
        public string? VaccinationLocation { get; set; }
        public int VaccinationDose { get; set; }
        public string? VaccinationBatch { get; set; }
        public string? Allergies { get; set; }
        public string? MedicalConditions { get; set; }
    }
}
