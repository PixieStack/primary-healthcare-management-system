namespace CodeMed.Models
{
    public class PrenatalSchedule
    {
        public int Id { get; set; }
        public int? Prefix { get; set; }
        public Patient? PatientId { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public DateTime PreferredDate { get; set; }
        public string? Services { get; set; }
        public string? StreetAddress { get; set; }
        public string? StreetAddressLine2 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }

        public class Patient
        {
            public string? PatientId;
            public string? Patientname;
        }
    }
}
