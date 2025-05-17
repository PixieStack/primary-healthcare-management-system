using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Counsellor
{
    public class Prenatal_Postpartum_Therapy
    {
        public int? ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Therapy_Date { get; set; }

        [Required]
        public string? Physical_Recovery { get; set; }

        [Required]
        public string? Emotional_Wellbeing { get; set; }

        [Required]
        public string? Breast_Feeding { get; set; }

        [Required]
        public string? Newborn_Care { get; set; }

        [Required]
        public string? Nutrition { get; set; }

        [Required]
        public string? Contraception { get; set; }

        [Required]
        public string? Physical_Activity { get; set; }

        [Required]
        public string? Sexual_Health { get; set; }

        [Required]
        public string? Follow_Up { get; set; }

        [Required]
        public string? Partner_Family_Support { get; set; }

        [Required]
        public string? Session_Notes { get; set; }
    }
}
