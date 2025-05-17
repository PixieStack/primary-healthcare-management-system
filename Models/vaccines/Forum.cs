using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.vaccines
{
    public class Forum
    {
        [Key]
        public int Id { get; set; }
        public string? PatientName { get; set; }
        public string? Post { get; set; }
        public string? Reply { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}
