namespace CodeMed.Models.Prenatal.Nurse
{
    public class PrenatalNurse_Referral
    {
        public int? ID { get; set; }
        public int? User_ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Referral_For { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Clinic_Number { get; set; }
        public string? Street_Address { get; set; }
        public string? Street_Address_line { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
        public string? Major_Complaint { get; set; }
        public string? Medical_History { get; set; }
        public string? Medical_Family_History { get; set; }
        public string? Diagnosis { get; set; }
        public string? Symptoms { get; set; }
        public string? Comments { get; set; }
    }
}
