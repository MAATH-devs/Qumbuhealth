using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Models;
using System.Security.Claims;

namespace Qumbu_Community_Health_Care_Center.Controllers
{
    public class FamilyPlanController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IEmailSender _email;
        public FamilyPlanController(ApplicationDbContext dbC, IEmailSender email)
        {
            _email = email;
            dbContext = dbC;
        }

        public IActionResult Patient()
        {
            return View();
        }
        public IActionResult Admin_Clerk()
        {
            return View();
        }
        public IActionResult Nurse()
        {
            return View();
        }
        public IActionResult NoAccess()
        {
            return View();
        }
        public IActionResult CreateAppointment()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                dbContext.Appointments.Add(appointment);
                dbContext.SaveChanges();
                return RedirectToAction("ViewAppointment");
            }
            return View(appointment);
        }


        public ActionResult ViewAppointment()
        {
            IEnumerable<Appointment> oblList = dbContext.Appointments;
            return View(oblList);
        }




        public ActionResult VievContraceptives()
        {
            IEnumerable<Appointment> Contraceptives = dbContext.Appointments;
            return View(Contraceptives);
        }
        public ActionResult CreateScreening()
        {
            return View();
        }


        public ActionResult CreateFeedback()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateFeedback(Feedbacks feedback)
        {
            if (ModelState.IsValid)
            {
                dbContext.Feedbacks.Add(feedback);
                dbContext.SaveChanges();
                return RedirectToAction("ViewFeedback");
            }
            return View(feedback);
        }
        public ActionResult ViewFeedback()
        {
            IEnumerable<Feedbacks> feedlist = dbContext.Feedbacks;
            return View(feedlist);
        }
        public IActionResult CreateFamilyReg()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> CreateFamilyReg( FamilyReg familyReg)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
			familyReg.PatientID = user;
            int totalReg = 0;
			if (ModelState.IsValid)
            {
                totalReg += Convert.ToInt32(familyReg.intercourse);
                totalReg += Convert.ToInt32(familyReg.period);
                totalReg += Convert.ToInt32(familyReg.child);
                totalReg += Convert.ToInt32(familyReg.experience);
                totalReg += Convert.ToInt32(familyReg.allaegies);
                totalReg += Convert.ToInt32(familyReg.medication);
                totalReg += Convert.ToInt32(familyReg.contraceptives);
                totalReg += Convert.ToInt32(familyReg.condom);
                totalReg += Convert.ToInt32(familyReg.smoke);
                totalReg += Convert.ToInt32(familyReg.normal);
                if(totalReg <= 30)
                {
                   TempData["Result"]= "Pills will be ";
                   TempData["_Image"] = "1";
                }
                else if( totalReg <= 40)
                {
                    TempData["Result"] = "1 month";
                    TempData["_Image"] = "2";
                }
                else if (totalReg <= 50)
                {
                    TempData["Result"] = "3 months";
                    TempData["_Image"] = "3";
                }
                else if (totalReg <= 60)
                {
                    TempData["Result"] = "1 implant";
                    TempData["_Image"] = "4";
                }
                else if (totalReg <= 70)
                {
                    TempData["Result"] = "3 loop";
                    TempData["_Image"] = "5";
                }
                else if (totalReg >= 80)
                {
                    TempData["Result"] = "Viginal Ring";
                    TempData["_Image"] = "6";
                }
                //familyReg .Total = totalReg;

                dbContext.FamilyReg.Add(familyReg);
                dbContext.SaveChanges();
                return RedirectToAction("ViewFamilyReg");

            }
			ViewData["PatientID"] = new SelectList(dbContext.Users, "Id", "Id", familyReg.PatientID);
			return View(familyReg);
		}
        public async Task<IActionResult> AcceptReg(int? ID)
        {
            var familyReg = dbContext.FamilyReg.Find(ID);
            if (familyReg != null)
            {
                familyReg.Status = "Accepted";
                dbContext.FamilyReg.Update(familyReg);
                await dbContext.SaveChangesAsync();
                TempData["Info"] = "The screening has been accepted";
                var patient = dbContext.Users.Where(a => a.Id == familyReg.PatientID).FirstOrDefault();
                try
                {
                    string supportEmail = "Qumbu_Community_Health_Care_Center.healthcare@gmail.com";
                    await _email.SendEmailAsync(patient.Email, "Confirm your email",
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
                       $"<Strong><p>Appointment Date: {familyReg.Date}</P></strong>" +
                       $"<Strong><p>Appointment Purpose: {familyReg.Status}</P></strong>" +
                       $"<p>Please be on time, atleast 10 minutes before</P>" +

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
                return RedirectToAction("ViewFamilyReg");
            }
            ViewData["PatientID"] = new SelectList(dbContext.Users, "Id", "Id", familyReg.PatientID);
            return View(familyReg);
        }

        public async Task <IActionResult> ViewFamilyReg()
        {
            var ApplicationDbContext = dbContext.FamilyReg.Include(f => f.MainUser);
            return View(await ApplicationDbContext.ToListAsync());
			//IEnumerable<FamilyReg> list = dbContext.FamilyReg;
			//return View(list);
		}
        public async Task <IActionResult> ListFamilyRegNurse()
        {
            var ApplicationDbContext = dbContext.FamilyReg.Include(f => f.MainUser);
            return View(await ApplicationDbContext.ToListAsync());
        }

		public ActionResult NurseAppointment()
		{
			IEnumerable<Appointment> oblList = dbContext.Appointments;
			return View(oblList);
		}
        public IActionResult updateFamilyReg(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();

            }
            var list = dbContext.FamilyReg.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult updateFamilyReg(FamilyReg familyReg)
        {
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            familyReg.PatientID = user;
            dbContext.FamilyReg.Update(familyReg);
            dbContext.SaveChanges();
            return RedirectToAction("ListFamilyRegNurse");
        }

        public IActionResult DeleteMenstruation(int? ID)
        {
            var list = dbContext.Menstruations.Find(ID);
            if (list == null)
            {
                return NotFound();
            }
            dbContext.Menstruations.Remove(list);
            dbContext.SaveChanges();
            return RedirectToAction("ViewMenstruaction");

        }
        public IActionResult UpdateMenstruation(int? ID)
        {
            if (ID == null || ID == 0)
            {
                return NotFound();
            }
            var obj = dbContext.Menstruations.Find(ID);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateMenstruation(Menstruation menstruation)
        {
            dbContext.Menstruations.Update(menstruation);
            dbContext.SaveChanges();
            return RedirectToAction("ViewMenstruaction");
        }
        public async Task<IActionResult> ViewReports()
        {
            ViewBag.Date = DateTime.Now.ToString("dd/mm/yyyy");
            ViewBag.Time = DateTime.Now.ToString("HH:MM");
            var applicationDbContext = dbContext.FamilyReg.Include(a => a.MainUser).ToList();
            return View(applicationDbContext);
        }
		public IActionResult CreateMenstruation()
		{
            var user = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.App = dbContext.Menstruations.ToList();
            ViewBag.Patient = (from U in dbContext.Users
                               join UR in dbContext.UserRoles on U.Id equals UR.UserId
                               join R in dbContext.Roles on UR.RoleId equals R.Id
                               where R.Name == "Patient"
                               select U).ToList();
            return View();
        }
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateMenstruation(Menstruation menstruation)
		{
			if (ModelState.IsValid)
			{
				dbContext.Menstruations.Add(menstruation);
				dbContext.SaveChanges();
				return RedirectToAction("ViewMenstruaction");
			}
			return View(menstruation);
		}
		public IActionResult ViewMenstruaction()
		{
			IEnumerable<Menstruation> list = dbContext.Menstruations;
			return View(list);
		}




	}
}
