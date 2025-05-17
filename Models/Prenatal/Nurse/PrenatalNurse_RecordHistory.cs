namespace CodeMed.Models.Prenatal.Nurse
{
    public class PrenatalNurse_RecordHistory
    {
        public int Id { get; set; }
        public int User_Id { get; set; }
        public string? Gender { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DOB_Month { get; set; }
        public string? DOB_Day { get; set; }
        public string? DOB_Year { get; set; }
        public string? Height { get; set; }
        public string? Weight { get; set; }
        public string? Email { get; set; }
        public string? Reason { get; set; }
        public string? Drug_Allergies { get; set; }
        public string? Illness { get; set; }
        public string? Other_Illness { get; set; }
        public string? Operations { get; set; }
        public string? Current_Medications { get; set; }
        public string? Excercise { get; set; }
        public string? Diet { get; set; }
        public string? Alcohol { get; set; }
        public string? Caffeine { get; set; }
        public string? Smoke { get; set; }
        public string? Comments { get; set; }
    }
}
