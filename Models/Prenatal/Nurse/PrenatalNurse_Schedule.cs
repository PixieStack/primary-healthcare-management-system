namespace CodeMed.Models.Prenatal.Nurse
{
    public class PrenatalNurse_Schedule
    {
        public int? ID { get; set; }
        public int? User_ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? StreetAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public string? Email { get; set; }
        public bool? AppliedBefore { get; set; }
        public string? Department { get; set; }
        public string? Procedure { get; set; }
        public DateTime? PreferredDate { get; set; }
    }
}
