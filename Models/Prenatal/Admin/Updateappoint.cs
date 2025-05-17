namespace CodeMed.Models.Prenatal.Admin
{
    public class Updateappoint
    {
        public int Id { get; set; }  
        public string? Name { get; set; }
        public string ?Surname { get; set; }

        public DateTime? CreatedDate { get; set; } = default(DateTime?);
    }
}
