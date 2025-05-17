namespace CodeMed.Models
{
    public class PrenatalAdminHistory
    {
        // Personal Information
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? PatientHeight { get; set; }
        public string? PatientWeight { get; set; }
        public string? PatientEmail { get; set; }
        public string? ReasonForVisit { get; set; }

        // Medical Information
        public string? MedicalHistory { get; set; }
        public string? Allergies { get; set; }
        public string? Illnesses { get; set; }
        public string? OtherIllnesses { get; set; }
        public string? Operations { get; set; }
        public string? CurrentMedications { get; set; }

        // Habits Information
        public string? Exercise { get; set; }
        public string? Diet { get; set; }
        public string? Alcohol { get; set; }
        public string? Caffeine { get; set; }
        public string? Smoking { get; set; }

        // Other Comments
        public string? OtherComments { get; set; }
    }
}

