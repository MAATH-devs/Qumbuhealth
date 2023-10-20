using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Build.Framework;
using System.ComponentModel;


namespace Qumbu_Community_Health_Care_Center.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    
    public string? FirstName { get; set; }
   
    public string? LastName { get; set; }

    //public DateTime? DateOfBirth { get; set; }
    public string? Tittle { get; set; }

    //    public string? Address { get; set; }

    //    public string? City { get; set; }
    //    public string? Role { get; set; }

    public string? MobileNumber { get; set; }
    //#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //    public ApplicationUser()
    //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    //    {
    //        City = "Not set";
    //        Role = "Not Set";
    //    }
}

