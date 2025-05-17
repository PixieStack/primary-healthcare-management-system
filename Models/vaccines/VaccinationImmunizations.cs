namespace CodeMed.Models.vaccines
{
    public class VaccinationImmunizations
    {
        public int Id { get; set; }
        public string? Doctor { get; set; }
        public string? Patient { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? AgeGroup { get; set; }
        public string? ParentName { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? VaccineType { get; set; }
        public DateTime VaccinationDate { get; set; }
        public DateTime NextVaccinationDate { get; set; }
    }
}
