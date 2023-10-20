using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class Menstruation
    {


		[Key]
		public int MenstruationId { get; set; }
		[Required]
		[DisplayName("Last time had periods?")]
		public DateTime Date { get; set; }
		[Required]
		[DisplayName("Upcoming date for periods?")]
		public DateTime EndDate { get; set; }
		public int difference { get; set; }


	}
}
