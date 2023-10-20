using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class Counsellor
    {
        [Key]
        public int CounsellorID { get; set; }
        public string? FullNames { get; set; }
        [Required]
        [DisplayName("D.O.B")]
        public string? DOB { get; set; }
        public string? Gender { get; set; }
        public string? Cell { get; set; }
        public string? Email { get; set; }
    }
}
