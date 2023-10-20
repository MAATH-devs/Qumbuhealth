using System.ComponentModel.DataAnnotations;

namespace Qumbu_Community_Health_Care_Center.Models
{
	public class UserVM
	{
		[Key]
		public int UserID { get; set; }
		[Required]
		public string? FirstName { get; set; }
		[Required]
		public string? LastName { get; set; }
		[Required]
		public string? Email { get; set; }
		[Required]
		public string? MobileNumber { get; set; }
		[Required]
		public string? Role { get; set; }
        [Required]
        public string? Tittle { get; set; }
    }
}
