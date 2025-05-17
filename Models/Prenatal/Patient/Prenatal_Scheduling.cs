namespace CodeMed.Models.Prenatal.Patient
{
    public class Prenatal_Scheduling
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone_Number { get; set; }
        public string? Email { get; set; }
        public string? Street_Address { get; set; }
        public string? Street_Address_Line { get; set; }
        public string? City { get; set; }
        public string? Province { get; set; }
        public string? Zip_Code { get; set; }
        public DateTime Date { get; set; }
        public string? Time { get; set; }
        public string? Message { get; set; }
    }
}
