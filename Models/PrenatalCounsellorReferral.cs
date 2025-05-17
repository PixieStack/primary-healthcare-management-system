namespace CodeMed.Models
{
    public class PrenatalCounsellorReferral
    {
        public int Id { get; set; }
        public string? ReferrerName { get; set; }
        public string? PatientName { get; set; }
        public DateTime? ReferralDate { get; set; }
        public string? ReferringHospital { get; set; }
        public string? ContactInfo { get; set; }
        public string? Notes { get; set; }
    }
}
