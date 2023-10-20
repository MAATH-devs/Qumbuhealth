using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Qumbu_Community_Health_Care_Center.Models
{
	public class Feedbacks
	{
		[Key]
		public int FeedbackId { get; set; }

		[Required]
		public string? Name { get; set; }
		[Required]
		[DisplayName("Type of contraceptives you used ?")]
		public string? Type { get; set; }
		[Required]
		[DisplayName("experience any effects ?")]
		public string? experience { get; set; }
		[Required]
		[DisplayName("Describe side effects")]
		public string? Description { get; set; }

	}
}
