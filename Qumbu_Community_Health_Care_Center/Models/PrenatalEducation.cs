
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Qumbu_Community_Health_Care_Center.Models
{
    public class PrenatalEducation
    {
        [Key]
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        [DisplayName("Publish date")]
        public DateTime PublishDate { get; set; } 
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public string? PatientID { get; set; }
        [ForeignKey("PatientID")]
        public virtual ApplicationUser? MainUser { get; set; }
        public string? PdfUrl { get; set; }
        [DisplayName("Choose the cover image of content")]
        [NotMapped]
        public IFormFile? CoverImage { get; set; }
        [DisplayName("Upload your content in pdf format")]
        [NotMapped]
        public IFormFile? ContentPdf { get; set; }
       
    }
}
