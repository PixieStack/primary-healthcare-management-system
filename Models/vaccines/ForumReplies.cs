using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models.vaccines
{
    public class ForumReplies
    {
        [Key]
        public int Id { get; set; }
        public string? PatientId { get; set; }
        public string? Reply { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
        public int PostId { get; set; }
    }
}
