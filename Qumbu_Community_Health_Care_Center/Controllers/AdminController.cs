using Microsoft.AspNetCore.Mvc;

namespace Qumbu_Community_Health_Care_Center.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Admin_Dashboard()
        {
            return View();
        }
        public IActionResult Patient_Reg()
        {
            return View();
        }
        public IActionResult Appointment_Booking()
        {
            return View();
        }
        public IActionResult Doctor()
        {
            return View();
        }
        public IActionResult Create_File()
        {
            return View();
        }
        public IActionResult Manage_Queue()
        {
            return View();
        }
		public IActionResult Admin_Report()
		{
			return View();
		}
	}
}
