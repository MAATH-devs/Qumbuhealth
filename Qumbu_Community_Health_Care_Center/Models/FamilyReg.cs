using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Controllers;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class FamilyReg
    {
        [Key]
        public int FamilyRegId { get; set; }

        [Display (Name = "Date")]
        [DataType (DataType.DateTime)]
        public DateTime Date { get; set; }

        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual ApplicationUser? MainUser { get; set;}
        public string? Status { get; set; } = "New";
       

        //Question
        [Required]
        [DisplayName("1.When was the last time you enganged in sexual intercourse?")]
        public int? intercourse { get; set; }

        [Required]
        [DisplayName("2.When was the last time you had your periods?")]

        public int? period { get; set; }

        [Required]
        [DisplayName("3.Do you have a child?")]

        public int? child { get; set; }

        [Required]
        [DisplayName("4.Have experince any morning sickness?")]

        public int? experience { get; set; }

        [Required]
        [DisplayName("5.do you have allergies?")]
        public int? allaegies { get; set; }

        [Required]
        [DisplayName("6.are you taking any medication?")]
        public int? medication { get; set; }

        [Required]
        [DisplayName("7.Have you ever used any contraceptives?")]
        public int? contraceptives { get; set; }


        [Required]
        [DisplayName("8.Do you use Condom?")]
        public int? condom{ get; set; }
		[Required]
		[DisplayName("9.Are they normal,Compared to the past  cycle?")]
		public int? normal { get; set; }
        [Required]
        [DisplayName("10.Do you Smoke?")]
        public int? smoke { get; set; }
       
        public FamilyReg()
        {
            Date = DateTime.Now;
           
        }
    }
   
}
