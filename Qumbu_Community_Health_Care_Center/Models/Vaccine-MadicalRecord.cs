using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;

namespace Qumbu_Community_Health_Care_Center.Models
{
	public class Vaccine_MadicalRecord
	{

		[Key]
		public int RecordID { get; set; }

		//      public int MedicalID { get; set; }
		//[ForeignKey("MedicalID")]
		//public virtual ApplicationUser? File { get; set; }

		[Required]
		[DisplayName("Blood Pressure")]
		public string? BloodPressure { get; set; }

		[Required]
		[DisplayName("Body Temperature ")]
		public int? Temperature { get; set; }

		[Required]
		[DisplayName("Heart Rate")]
		public int? HateReate { get; set; }

		[Required]
		[DisplayName("Date Of Vaccination")]
		public DateTime? Date { get; set; } = DateTime.Now;

		[Required]
		[DisplayName("Weight (Kg)")]
		public int? Weight { get; set; }


		//public int NurseID { get; set; }
		//[ForeignKey("NurseID")]
		//public virtual ApplicationUser? Nurse { get; set; }
	}
}
