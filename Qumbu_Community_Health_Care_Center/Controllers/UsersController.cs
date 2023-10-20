using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Qumbu_Community_Health_Care_Center.Areas.Identity.Data;
using Qumbu_Community_Health_Care_Center.Models;
using Qumbu_Community_Health_Care_Center.Services;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace Qumbu_Community_Health_Care_Center.Controllers
{
	public class UsersController : Controller
	{	
		private readonly ApplicationDbContext _context;
		private readonly IEmailSender _emailSender;
		private readonly UserManager<ApplicationUser> _userManager;
		public UsersController(ApplicationDbContext context, IEmailSender email, UserManager<ApplicationUser> userManager)
		{
			_context = context;
			_emailSender = email;
			_userManager= userManager;
		}
		public IActionResult Index()
		{
			var UserList = _context.Users.ToList();
			ViewBag.List = UserList;
			return View();
		}
		public async Task<IActionResult> Add_New_User()
		{
			ViewBag.Roles = _context.Roles.ToList();
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Add_New_User(UserVM user)
		{
			if (ModelState.IsValid)
			{
				var ourUser = new ApplicationUser()
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email,
					EmailConfirmed = true,
					UserName = user.Email,
				};
				string Passwords = "Qumbu" + user.FirstName + user.Email + "2023@";
				var result = await _userManager.CreateAsync(ourUser, Passwords);
				if(result.Succeeded)
				{
					await _userManager.AddToRoleAsync(ourUser, user.Role);
					await _emailSender.SendEmailAsync(ourUser.Email, "Welcome to Qumbu health Care Center",
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
					   $"<h1>welcome to Qumbu health Care Center!</h1>" +
					   $"<p>Dear {user.FirstName} {user.LastName},</p." +
					   $"<p>Your User Account is created. You can log in using your log in details below.</p." +
					   $"<p>Email: {ourUser.Email}</p>" +
					   $"<p>Password: {Passwords}</p>" +
					   $"<p>Please direct any queries to info@QumbuHealth.com.</p." +
					   $"<dic class='footer'>" +
					   $"<p>Thank you</p>" +
					   $"<p>Qumbu health team.</p>" +
					   $"</div>" +
					   $"</body>" +
					   $"</html>");
					//var loginUser = User.FindFirstValue(ClaimTypes.NameIdentifier);
					//var alert = new Alerts()
					//{
					//	IntendedUser = loginUser,
					//	MessagePack = "New User has been created",
					//	Role = "Notification",
					//};
					//_context.Alerts.Add( alert );
					//await _context.SaveChangesAsync();
					TempData["Success"] = "User Added successfully";
					TempData["Email"] = "Please log in to youe emails and confirm email";
					return RedirectToAction(nameof(Index));
				}
			}
			return View();
		}
	}
}
