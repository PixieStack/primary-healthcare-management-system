using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Doctor
{
    public class Prenatal_Obstetrician_Monitoring
    {
        public int ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string? Blood_Pressure { get; set; }

        [Required]
        public string? Heart_Rate { get; set; }

        [Required]
        public string? Temperature { get; set; }

        [Required]
        public string? Weight { get; set; }

        [Required]
        public string? Urine_Test { get; set; }

        [Required]
        public string? Blood_Test { get; set; }

        [Required]
        public string? Ultrasound { get; set; }

        [Required]
        public string? Fetal_Movement { get; set; }

        [Required]
        public string? Funda_Height { get; set; }

        [Required]
        public string? Genetic_Screening { get; set; }

        [Required]
        public string? Glucose_Test { get; set; }

        [Required]
        public string? Infection_Screening { get; set; }

        [Required]
        public string? Emotional_Wellbeing { get; set; }

    }
}
