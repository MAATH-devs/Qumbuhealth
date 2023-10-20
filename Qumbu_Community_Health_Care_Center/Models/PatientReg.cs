using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class PatientReg
    {
        [Key]
        public int PatientRegId { get; set; }
        public int? kinCell { get; set; }
        [Required]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [Required]
        [DisplayName("Surname")]
        public string? Surname { get; set; }
        [Required]
        [DisplayName("Identity Number")]
        public string? IDno { get; set; }
        [Required]
        [DisplayName("Next of Kin Name")]
        public string? kinName { get; set; }
        [Required]
        [DisplayName("Next of Kin Surname")]
        public string? kinSurname { get; set; }
        [Required]
        [DisplayName("D.O.B")]
        public string? DOB { get; set; }
        [Required]
        [DisplayName("Tittle")]
        public string? Tittle { get; set; }
        public string? Address { get; set; }
        public string? Occupation { get; set; }
        public string? kinAddress { get; set; }
        public string? Cell { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public string? Province { get; set; }
        public string? kinProvince { get; set; }
        public string? Race { get; set; }
        [Required]
        [DisplayName("Marital Status")]
        public string? Status { get; set; }
        [Required]
        [DisplayName("Relation to the client: ")]
        public string? Relationship { get; set; }
        [Required]
        [DisplayName("Referral Source")]
        public string? Source { get; set; }
        [Required]
        [DisplayName("Previous Counselling Experience")]
        public string? Experience { get; set; }
        [Required]
        [DisplayName("Medical & Mental Health")]
        public string? Health { get; set; }
        [Required]
        [DisplayName("Current Medication")]
        public string? Medication { get; set; }
        [Required]
        [DisplayName("Family History")]
        public string? History { get; set; }
        [Required]
        [DisplayName("Preferred Communication & Consent")]
        public string? Communication { get; set; }
        [Required]
        [DisplayName("Current Stressors")]
        public string? CurrentStressors { get; set; }
        [Required]
        [DisplayName("Reason for Seeking Counselling: ")]
        public string? Reason { get; set; }
        [Required]
        [DisplayName("Mental Health History")]
        public string? MentalHis { get; set; }
        [DisplayName("Background and History")]
        public string? Background { get; set; }
        [Required]
        [DisplayName("Current Concerns and Symptoms: ")]
        public string? Symptoms { get; set; }
        [Required]
        [DisplayName("Goals and Expectations")]
        public string? Expectations { get; set; }
        [Required]
        [DisplayName("Cultural and Social Information")]
        public string? SocialInfo { get; set; }
        [Required]
        [DisplayName("Legal or Safety Concerns: ")]
        public string? Safety { get; set; }
        [Required]
        [DisplayName("Consent & Confidentiality: ")]
        public string? Consent { get; set; }
        [Required]
        [DisplayName("Signature & Date: ")]
        public string? Sign { get; set; }
        public string? Religion { get; set; }
        public string? regDate { get; set; }
        public string? Language { get; set; }
    }
}
