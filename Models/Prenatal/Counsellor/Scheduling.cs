namespace CodeMed.Models.Prenatal.Counsellor
{
    public class Scheduling
    {
        public int? ID { get; set; }
        public string? FirstName { get; set; }
        public string? LAstName { get; set; }
        public string? Email { get; set; }
        public string? Phone_Number { get; set; }
        public string? Contact_Method { get; set; }
        public string? Medical_Department { get; set; }
        public string? Date_Month { get; set; }
        public string? Date_Day { get; set; }
        public string? Date_Year { get; set; }
        public DateTime? Time { get; set; }
    }
}
