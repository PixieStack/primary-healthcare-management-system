namespace CodeMed.Models.Prenatal.Doctor
{
    public class PrenatalDoctor_Medication
    {
        public int? Id { get; set; } 
        public int? User_Id { get; set; } 
        public string? FirstName { get; set; } 
        public string? LastName { get; set; } 
        public string? Trimester { get; set; } 
        public string? Medication_Name { get; set; } 
        public string? Dose_Period { get; set; } 
        public string? Dose_Count { get; set; } 
        public string? Dose_Count_Total { get; set; } 
        public string? Directions { get; set; } 
        public string? Recommended_Time { get; set; } 
        public string? Side_Effects { get; set; } 

    }
}
