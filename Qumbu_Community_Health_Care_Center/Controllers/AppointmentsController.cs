using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Models;
using Qumbu_Community_Health_Care_Center.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;


namespace Qumbu_Community_Health_Care_Center.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext Context;
        private readonly IEmailSender _email;
        public AppointmentsController(ApplicationDbContext DbContext,IEmailSender email)
        {
            _email = email;
            Context = DbContext;
        }
        public async Task<IActionResult> Index()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var applicationDbContext = Context.Appointments.Include(a => a.MainUser).Where(a => a.PatientID == user);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> All_Appointments()
        {
           
            var applicationDbContext = Context.Appointments.Include(a => a.MainUser).ToList();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> Report()
        {
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			ViewBag.Date = DateTime.Now.ToString("dd/mm/yyyy");
			ViewBag.Time = DateTime.Now.ToString("HH:MM");
            var applicationDbContext = Context.Appointments.Include(a => a.MainUser).Where(a => a.Purpose == "Counselling").ToList();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> Counselling()
        {

            var applicationDbContext = Context.Appointments.Include(a => a.MainUser).Where(a => a.Purpose == "Counselling").ToList();
            return View(applicationDbContext);
        }
        public async Task<IActionResult> Family()
        {

            var applicationDbContext = Context.Appointments.Include(a => a.MainUser).Where(a => a.Purpose == "Family-Planning").ToList();
            return View(applicationDbContext);
        }
        //admin creates appointment based on the patient id
        public IActionResult Create()
        {
			var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			ViewBag.App = Context.Appointments.Where(a => a.PatientID == user).ToList();
            ViewBag.Patient = (from U in Context.Users
                                  join UR in Context.UserRoles on U.Id equals UR.UserId
                                  join R in Context.Roles on UR.RoleId equals R.Id
                                  where R.Name == "Patient"
                                  select U).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Appointment appointments)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            appointments.PatientID = user;
            if (ModelState.IsValid)
            {
                Context.Appointment.Add(appointments);
                await Context.SaveChangesAsync();
                TempData["Success"] = "Succesfully booked";
                try
                {
                    string supportEmail = "Qumbuhealthcare@gmail.com";
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    await _email.SendEmailAsync(email, "For appointment",
                        $"<html><head><style>body{{font-family:Arial,sans-serif;}}" +
                        $"h1{{color:#336699;}}" +
                        $".cta-button{{background-color:#336699;color:@fff;" +
                        $"padding:10px 20px;" +
                        $"text-decoration:none;border-radius:5px;}}" +
                        $".cta-button:hover{{background-color:#265580;}}" +
                        $".footer{{margin-top:20px;font-size:12px;color:#888;}}" +
                        $"</style>" +
                        $"</head>" +
                        $"<body>" +
                        $"" +
                        $"<h1>Qumbu Healthcare Center!</h1>" +
                        $"<p></p>" +
                        $"<p> Thank for booking with us.</P>" +
                        $"<p>Take note that your appointment has been booked successfully</P>" + 
                        $"<Strong><p>Appointment Date: {appointments.Date_Time}</P></strong>" +
                        
                        $"" +
                        $"if you have any question ,contact our team at {supportEmail}</p>" +
                        $"<dic class='footer'>" +
                        $"<p>Thank you</p>" +
                        $"</div>" +
                        $"</body>" +
                        $"</html>");
                }
                catch (Exception ex)
                {
                    TempData["Success"] = "Succesfully booked but email notification failed.";
                }
                return RedirectToAction("Create");
            }
            ViewBag.App = Context.Appointments.Where(a => a.PatientID == user).ToList();
            ViewData["PatientID"] = new SelectList(Context.Users, "Id", "Id", appointments.PatientID);
            return View(appointments);
        }
        public IActionResult P_Create()
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.App = Context.Appointments.Where(a => a.PatientID == user).ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> P_Create(Appointment appointments)
        {
            if (ModelState.IsValid)
            {
                Context.Appointment.Add(appointments);
                await Context.SaveChangesAsync();
                TempData["Success"] = "Succesfully booked";
                try
                {
                    string supportEmail = "Qumbuhealthcare@gmail.com";
                    var email = User.FindFirstValue(ClaimTypes.Email);
                    await _email.SendEmailAsync(email, "For appointment",
                        $"<html><head><style>body{{font-family:Arial,sans-serif;}}" +
                        $"h1{{color:#336699;}}" +
                        $".cta-button{{background-color:#336699;color:@fff;" +
                        $"padding:10px 20px;" +
                        $"text-decoration:none;border-radius:5px;}}" +
                        $".cta-button:hover{{background-color:#265580;}}" +
                        $".footer{{margin-top:20px;font-size:12px;color:#888;}}" +
                        $"</style>" +
                        $"</head>" +
                        $"<body>" +
                        $"" +
                        $"<h1>Qumbu Healthcare Center!</h1>" +
                        $"<p></p>" +
                        $"<p> Thank for booking with us.</P>" +
                        $"<p>Take note that your appointment has been booked successfully</P>" +
                        $"<Strong><p>Appointment Date: {appointments.Date_Time}</P></strong>" +

                        $"" +
                        $"if you have any question ,contact our team at {supportEmail}</p>" +
                        $"<dic class='footer'>" +
                        $"<p>Thank you</p>" +
                        $"</div>" +
                        $"</body>" +
                        $"</html>");
                }
                catch (Exception ex)
                {
                    TempData["Success"] = "Succesfully booked but email notification failed.";
                }
                return RedirectToAction("P_Create");
            }
            ViewData["PatientID"] = new SelectList(Context.Users, "Id", "Id", appointments.PatientID);
            return View(appointments);
        }
        public async Task<IActionResult> Accept(int? id)
        {
            var appointments = Context.Appointments.Find(id);
            if (appointments != null)
            {
                appointments.Status = "Accepted";
                Context.Appointments.Update(appointments);
                await Context.SaveChangesAsync();
                TempData["Success"] = "The appointment has been accepted";
                var patient = Context.Users.Where(a => a.Id == appointments.PatientID).FirstOrDefault();
                try
                {
                    string supportEmail = "Qumbuhealthcare@gmail.com";
                     await _email.SendEmailAsync(patient.Email, "Appointment Accepted",
                         $"<html><head><style>body{{font-family:Arial,sans-serif;}}" +
                         $"h1{{color:#336699;}}" +
                         $".cta-button{{background-color:#336699;color:@fff;" +
                         $"padding:10px 20px;" +
                         $"text-decoration:none;border-radius:5px;}}" +
                         $".cta-button:hover{{background-color:#265580;}}" +
                         $".footer{{margin-top:20px;font-size:12px;color:#888;}}" +
                         $"</style>" +
                         $"</head>" +
                         $"<body>" +
                         $"" +
                         $"<h1>Qumbu Healthcare Center!</h1>" +
                         $"<p></p>" +
                         $"<p> Thank for booking with us.</P>" +
                         $"<p>Take note that your appointment has been accepted</P>" +
                         $"<Strong><p>Appointment Date: {appointments.Date_Time}</P></strong>" +
                         $"<Strong><p>Appointment Purpose: {appointments.Purpose}</P></strong>" +
                         $"<p>Please be on time, atleast 15 minutes before</P>" +

                         $"" +
                         $"if you have any question ,contact our team at {supportEmail}</p>" +
                         $"<dic class='footer'>" +
                         $"<p>Thank you</p>" +
                         $"</div>" +
                         $"</body>" +
                         $"</html>");
                }
                catch
                {

                }
                return RedirectToAction("All_Appointments");
            }
            ViewData["PatientID"] = new SelectList(Context.Users, "Id", "Id", appointments.PatientID);
            return View(appointments);
        }
        public IActionResult Edit(int?id)
        {
            if(id == null || Context.Appointments == null)
            {
                return NotFound();
            }
            var appointments = Context.Appointments.Find(id);
            if (appointments == null)
            {
                return NotFound();
            }
            ViewData["PatientID"] = new SelectList(Context.Users, "Id", "Id", appointments.PatientID);
            return View(appointments);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Appointment appointments)
        {
            if(id != appointments.AppointmentID)
            {
                return NotFound();
            }
            else 
            {
                try
                {
                    var appoint = Context.Appointment.Where(a => a.AppointmentID == id).FirstOrDefault();
                    appoint.Date_Time = appointments.Date_Time;
                    Context.Update(appoint);
                    Context.SaveChanges();
                    TempData["Success"] = "The appointment has been postponed";
                    var patient = Context.Users.Where(a => a.Id == appoint.PatientID).FirstOrDefault();
                    try
                    {
                        string supportEmail = "Qumbuhealthcare@gmail.com";
                        _email.SendEmailAsync(patient.Email, "Confirm your email",
                            $"<html><head><style>body{{font-family:Arial,sans-serif;}}" +
                            $"h1{{color:#336699;}}" +
                            $".cta-button{{background-color:#336699;color:@fff;" +
                            $"padding:10px 20px;" +
                            $"text-decoration:none;border-radius:5px;}}" +
                            $".cta-button:hover{{background-color:#265580;}}" +
                            $".footer{{margin-top:20px;font-size:12px;color:#888;}}" +
                            $"</style>" +
                            $"</head>" +
                            $"<body>" +
                            $"" +
                            $"<h1>Qumbu Healthcare Center!</h1>" +
                            $"<p></p>" +
                            $"<p> Thank for booking with us.</P>" +
                            $"<p>Take note that your appointment has been postpone with the following details</P>" +
                            $"<Strong><p>Appointment Date: {appointments.Date_Time}</P></strong>" +
                            $"<Strong><p>Appointment Purpose: {appointments.Purpose}</P></strong>" +
                            $"<p>Please be on time, atleast 10 minutes before</P>" +

                            $"" +
                            $"if you have any question ,contact our team at {supportEmail}</p>" +
                            $"<dic class='footer'>" +
                            $"<p>Thank you</p>" +
                            $"</div>" +
                            $"</body>" +
                            $"</html>");
                        return RedirectToAction("All_Appointments");
                    }
                    catch
                    {
                        return RedirectToAction("Index");
                    }
                } 
                catch(DbUpdateConcurrencyException)
                {
                    //if(!AppointmentExists(appointments.AppointmentID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
            }
            ViewData["PatientID"] = new SelectList(Context.Users, "Id", "Id", appointments.PatientID);
            return View(appointments);
        }
    }
}
