using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.Prenatal.Doctor
{
    public class Prenatal_Obstetrician_Medication
    {
		public int Id { get; set; } // Id is not nullable

		[Required]
		public string? Obstetrician { get; set; } // Obstetrician is required

		[Required]
		public string? Patient { get; set; } // Patient is required

		[Required]
		public string? Medication_Name { get; set; } // Medication_Name is required

		[Required]
		public DateTime? Start_Date { get; set; } // Start_Date is required

		[Required]
		public DateTime? End_Date { get; set; } // End_Date is required

		[Required]
		public string? Trimester { get; set; } // Trimester is required

		[Required]
		public string? Dose_Period { get; set; } // Dose_Period is required

		[Required]
		public int? Dosage { get; set; } // Dosage is required

		[Required]
		public string? Directions { get; set; } // Directions is required

		[Required]
		public string? Side_Effects { get; set; } // Side_Effects is required

	}
}
