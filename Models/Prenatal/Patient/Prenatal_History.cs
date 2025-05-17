namespace CodeMed.Models.Prenatal.Patient
{
    public class Prenatal_History
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public string? Gender { get; set;}
        public string? FirstName { get; set;}
        public string? LastName { get; set;}
        public string? Birth_Month { get; set;}
        public string? Birth_Day { get; set;}
        public string? Birth_Year { get; set;}
        public string? Height { get; set;}
        public string? Weight { get; set;}
        public string? Email { get; set;}
        public string? Reason { get; set;}
        public string? Drug_Allergy { get; set;}
        public string? Illness { get; set;}
        public string? Other_Illness { get; set;}
        public string? Operation_Info { get; set;}
        public string? Current_Meds { get; set;}
        public string? Exercise { get; set;}
        public string? Diet { get; set;}
        public string? Alcohol_Consumption { get; set;}
        public string? Caffeine_Consumption { get; set;}
        public string? Smoke { get; set;}
        public string? Comments { get; set;}
    }
}
