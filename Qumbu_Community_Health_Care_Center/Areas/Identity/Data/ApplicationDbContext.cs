using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Models;

namespace Qumbu_Community_Health_Care_Center.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)   : base(options)
    {
       
    }
    public DbSet<MedicalFile> MedicalFile { get; set; }
    public DbSet<Bookings> Bookings { get; set; }
    public DbSet<PatientReg> PatientReg { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<ScreeningTool> Srcreening { get; set; }
    public DbSet<Feedbacks> Feedbacks { get; set; }
    public DbSet<HealthRecord> HealthRecords { get; set; }
    public DbSet<Referral> Referral { get; set; }
    public DbSet<FamilyReg> FamilyReg { get; set; }
    public DbSet<FeedbackV> VaccinationFeedback { get; set; }
    public DbSet<VaccsAppointment> VaccinationAppointment { get; set; }
    public DbSet<VaccsRecord>Records { get; set; }
    public DbSet<UltrasoundAppointment> Ultrasounds { get; set; }
    public DbSet<Profiling> Profiling { get; set; }
    public DbSet<Appointment> Appointment {  get; set; }
    public DbSet<PrenatalEducation> prenatalEducation { get; set; }
    public DbSet<Menstruation> Menstruations { get; set; }
	public DbSet<VaccinationEducation> VaccineEducation { get; set; }
	public DbSet<Vaccine_MadicalRecord> vaccinerecord { get; set; }
   
	
	protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
	}
    public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(255);
            builder.Property(u => u.LastName).HasMaxLength(255);
        }
    }
    public DbSet<Qumbu_Community_Health_Care_Center.Models.UserVM>? UserVM { get; set; }
    public DbSet<Qumbu_Community_Health_Care_Center.Models.Medical_File>? Medical_File { get; set; }

}
