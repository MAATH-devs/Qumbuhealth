using Microsoft.AspNetCore.Identity;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class Medical_File
    {
        [Key]
        public int fileId { get; set; }

        [Required]
        [Display(Name = "Patient Name")]
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]

        public virtual ApplicationUser? mainUser { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your ID number")]
        [Display(Name = "ID Number")]
        [MaxLength(13)]
        [MinLength(13)]
        public string? IDNumber { get; set; }

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateofBirth { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string? Gender { get; set; }
        [DisplayName("Marital Stataus")]
        public string? Status { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Province")]
        public string? Province { get; set; }
        [Required]
        [Display(Name = "Postal code")]
        public string? postalCode { get; set; }


        //next of kin information
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Please enter enter letters only")]
        [PersonalData]
        [Display(Name = "Full Name(s)")]
        [MaxLength(80)]
        [MinLength(3)]
        [AllowNull]
        public string? NextfoKin { get; set; }

        [Display(Name = "Cell Number")]
        [AllowNull]
        public string? kinCell { get; set; }

        [Display(Name = "Relationship")]
        public string? Relationship { get; set; }

        //Medical history 
        [Display(Name = "Patient blood type")]
        public string? BloodType { get; set; }

        [Display(Name = "Any allergies")]
        public string? Allergies { get; set; }
        [Display(Name = "Had surgery before?")]
        public string? Surgery { get; set; }
        [Display(Name = "Notes")]
        public string? extraNotes { get; set; }

        public Medical_File()
        {
            BloodType = "Not Sure";
            Surgery = "None";
            Surgery = "No";
        }


    }
}
