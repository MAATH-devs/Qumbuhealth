using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;

namespace Qumbu_Community_Health_Care_Center.Models
{
	public class VaccinationEducation
	{
		[Key]
		public int EducationID { get; set; }

		[Required]
		//[DisplayName("1) Do you have any allergies ?")]
		public string? VaccineName { get; set; }

		[Required]
		public string? Description { get; set; }
		[Required]
		public string? Purpose { get; set; }

	}
}
