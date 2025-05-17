using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models
{
    public class AppointmentRequest
    {
        [Key]
        public int ID { get; set; }
        public string? Patient { get; set; }
        public string? SelectedService { get; set; }
        public string? SelectedProviderType { get; set; }
        public DateTime PreferredDate { get; set; }
        public string? PreferredTime { get; set; }

        // Add properties for provider IDs
        public string? ObstetricianId { get; set; }
        public string? DoctorId { get; set; }
        public string? NurseId { get; set; }
        public string? CounsellorId { get; set; }

        public string? FamilyPlanningServiceType { get; set; }
        public string? CounsellingServiceType { get; set; }
        public string? ChronicMedicationServiceType { get; set; }
        public string? WalkInServiceType { get; set; }
        public string? VaccinationServiceType { get; set; }
        public string? PrenatalCareServiceType { get; set; }

    }
}
