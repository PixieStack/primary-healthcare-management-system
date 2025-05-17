using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Counsellor
{
    public class Prenatal_TeenMoms_Therapy
    {
        public int? ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Therapy_Date { get; set; }

        [Required]
        public string? Education { get; set; }

        [Required]
        public string? Parenting_Skills { get; set; }

        [Required]
        public string? Health_Wellbeing { get; set; }

        [Required]
        public string? Birth_Control { get; set; }

        [Required]
        public string? Financial_Management { get; set; }

        [Required]
        public string? Support_Systems { get; set; }

        [Required]
        public string? Self_Care { get; set; }

        [Required]
        public string? Long_term_Goals { get; set; }

        [Required]
        public string? Session_Notes { get; set; }

    }
}
