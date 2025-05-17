using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Counsellor
{
    public class Prenatal_Grief_Therapy
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public string? Obstetrician { get; set; }

        [Required]
        public string? Patient { get; set; }

        [Required]
        public DateTime? Date { get; set; }

        [Required]
        public string? Coping_Strategies { get; set; }

        [Required]
        public string? Future_Plans { get; set; }

        [Required]
        public string? Notes { get; set; }

        [Required]
        public string? Baby_Name { get; set; }

        [Required]
        public string? Loss_Type { get; set; }

        [Required]
        public DateTime? Due_Date { get; set; }
    }
}
