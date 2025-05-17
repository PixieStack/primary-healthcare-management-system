using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Counsellor
{
    public class Prenatal_Stress_Therapy
    {
        public int? ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Therapy_Date { get; set; }

        [Required]
        public string? Current_Stressors { get; set; }

        [Required]
        public string? Relaxation_Techniques { get; set; }

        [Required]
        public string? Coping_Strategies { get; set; }

        [Required]
        public string? Support_System { get; set; }

        [Required]
        public string? Handling_Stress { get; set; }

        [Required]
        public string? Stress_Triggers { get; set; }

        [Required]
        public string? Session_Notes { get; set; }
    }
}
