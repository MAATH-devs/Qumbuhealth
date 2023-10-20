using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;


namespace Qumbu_Community_Health_Care_Center.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }
        public string? Names { get; set; }
        public DateTime Date { get; set; }
        public string? Departments { get; set; }
        public TimeSpan? Time { get; set; }
        public string? Contact { get; set; }
    }
}
