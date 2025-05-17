using System.Data;

namespace CodeMed.Models.chronic
{
    public class reviews
    {
        public int Id { get; set; }
        public string? Patient { get; set; }
        public string? review { get; set; }
        public int? One_stars { get; set; }
        public int? Two_stars { get; set; }
        public int? Three_stars { get; set; }
        public int? Four_stars { get; set; }
        public int? Five_stars { get; set; }

    }
}
