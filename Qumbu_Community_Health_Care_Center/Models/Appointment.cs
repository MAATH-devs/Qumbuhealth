using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qumbu_Community_Health_Care_Center.Models
{
	public class Appointment
	{
		[Key]
		public int AppointmentID { get; set; }
		
		[DataType(DataType.DateTime)]

        [Display(Name = "Booking Day")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Purpose for the appointment")]
        public string? Purpose { get; set; }
		public string? Status { get; set; } = "New";
        public string? PatientID { get; set; }
		[ForeignKey("PatientID")]
        [Display(Name = "Full Name")]
        public virtual ApplicationUser? MainUser { get; set; }
		[Required]
		[Display(Name = "Appointment Day")]
		[DataType(DataType.DateTime)]
		public DateTime Date_Time { get; set; }
        //public string? Notes { get; set; }
        //[Display(Name = "Patient Name")]
        //public string? Name { get; set; }
        //[Display(Name = "Patient Surname")]
        //public string? Surname { get; set; }
	}
}
