namespace CodeMed.Models.Prenatal.Patient
{
    public class Prenatal_ViewAppointment
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime Date { get; set; }
        public DateTime? Time { get; set; }
        public string? Location { get; set; }
        public string? Contact_Number { get; set; }
    }
}
