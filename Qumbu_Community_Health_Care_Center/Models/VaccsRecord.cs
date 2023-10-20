using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections.Generic;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class VaccsRecord
    {
        [Key]
        public int PatientID { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string? Vame { get; set; }
        [Required]
        [DisplayName(" Last Name ")]
        public string? Surname { get; set; }
        [Required]
        [DisplayName(" Age")]
        public int Age { get; set; }
        //[Required]
        //[DisplayName("")]
        //public string? Question4 { get; set; }
        //[Required]
        //[DisplayName("5) Do you have shortness of breath or difficulty in breathing ?")]
        //public string? Question5 { get; set; }
        //[Required]
        //[DisplayName("6) Do you have headache ?")]
        //public string? Question6 { get; set; }
    }
}
