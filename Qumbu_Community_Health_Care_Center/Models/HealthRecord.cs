using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Qumbu_Community_Health_Care_Center.Models
{
    public class HealthRecord
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string UserId { get; set; }
        [Required]
        [DisplayName("Recorded Date")]
        public DateTime RecordedDate { get; set; }
        [Required]
        public double Weight { get; set; }
        [Required]
        [DisplayName("Blood Pressure Systolic")]
        public int BloodPressureSystolic { get; set; }
        [Required]
        [DisplayName("Blood Pressure Diastolic")]
        public int BloodPressureDiastolic { get; set; }
        [Required]
        public string Symptoms { get; set; }
    }
}
