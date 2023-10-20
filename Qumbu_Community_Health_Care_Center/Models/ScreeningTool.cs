using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class ScreeningTool
    {
		[Key]
		public int ScreeningID { get; set; }

		public string? PatientID { get; set; }
		[ForeignKey("PatientID")]
		public virtual ApplicationUser? Patient { get; set; }


		[Required]
		[DisplayName("1) Do you have any allergies ?")]
		public int? Question1 { get; set; }

		[Required]
		[DisplayName("2) Are you pregnant? ?")]
		public int? Question2 { get; set; }

		[Required]
		[DisplayName("3) Are you sick today ?")]
		public int Question3 { get; set; }

		[Required]
		[DisplayName("4) Are you coughing")]
		public int? Question4 { get; set; }

		[Required]
		[DisplayName("5) Do you have shortness of breath or difficulty in breathing ?")]
		public int? Question5 { get; set; }

		[Required]
		[DisplayName("6) Do you have headache ?")]
		public int? Question6 { get; set; }

        [Required]
        [DisplayName("Date")]
        public DateTime? Date { get; set; } = DateTime.Now;
        //public List<string> Symptoms { get; set; }

        //public bool IsHighRisk { get; set; }

        //public ScreeningTool()
        //{
        //    Symptoms = new List<string>();
        //}

        //public void CalculateRisk()
        //{
        //    IsHighRisk = (Age > 60) || (Symptoms.Contains("Fever") && Symptoms.Contains("Cough"));
        //}


    }
}
