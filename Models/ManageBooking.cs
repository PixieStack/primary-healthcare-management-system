namespace CodeMed.Models
{
    public class ManageBooking
    {
        public int ID { get; set; }

        public string? Name { get; set; }
        public string? Surname { get; set; }

        public DateTime? CreatedDate { get; set; } = default;
    }
}
