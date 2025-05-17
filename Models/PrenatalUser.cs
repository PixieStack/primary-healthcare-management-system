using System.ComponentModel.DataAnnotations;

namespace CodeMed.Models
{
    public class PrenatalUser
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public string? Citizenship { get; set; }

        
        public string? ID_Number { get; set; }

        
        public string? Passport_Number { get; set; }

        [Required]
        public string? First_Name { get; set; }

        [Required]
        public string? Last_Name { get; set; }

        [Required]
        public string? Role { get; set; }

        [Required]
        public string? Home_Address { get; set; }

        [Required]
        public string? Phone_Number { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }

        [Required]
        public string? ConfirmPassword { get; set; }
    }

}
