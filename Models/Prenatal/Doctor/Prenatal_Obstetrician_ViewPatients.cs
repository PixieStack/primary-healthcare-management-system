using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Doctor
{
    public class Prenatal_Obstetrician_ViewPatients
    {
        public int ID { get; set; }

        [Required]
        public string? User_ID { get; set; }

        [Required]
        public string? FirstName { get; set; }

        [Required]
        public string? LastName { get; set; }

        [Required]
        public string? ID_Number { get; set; }

    }
}
