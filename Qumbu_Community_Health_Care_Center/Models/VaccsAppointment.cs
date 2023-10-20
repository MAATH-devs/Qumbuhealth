using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class VaccsAppointment
    {
		[Key]
		public int ID { get; set; }
		[Required]
        [DisplayName("First Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName(" Last Name ")]
        public string? Surname { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName(" Date Of Appointment")]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [DisplayName(" Time Of Appointment")]
        public TimeSpan Time { get; set; }


    }
}
