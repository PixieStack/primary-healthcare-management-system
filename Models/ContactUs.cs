using System.ComponentModel.DataAnnotations;
namespace CodeMed.Models
{
	public class ContactUs
	{
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
		public string? Name { get; set; }

		[Required(ErrorMessage = "Please enter your surname.")]
		public string? Surname { get; set; }

		[Required(ErrorMessage = "Please enter your phone number.")]
		[Phone(ErrorMessage = "Please enter a valid phone number.")]
		public string? PhoneNumber { get; set; }

		[Required(ErrorMessage = "Please enter your email address.")]
		[EmailAddress(ErrorMessage = "Please enter a valid email address.")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Please enter your message.")]
		public string? Message { get; set; }
	}
}
