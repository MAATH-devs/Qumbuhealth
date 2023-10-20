using System.ComponentModel.DataAnnotations;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class Referral
    {
        [Key]
        public int ReferralID { get; set; }
        public string?  PatientName { get; set; }
        public string? Departments { get; set; }
        public string? Remarks { get; set; }
    }
}
