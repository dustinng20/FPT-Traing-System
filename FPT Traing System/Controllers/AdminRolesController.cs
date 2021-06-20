using FPT_Traing_System.Models;
using FPT_Traing_System.viewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
	public class AdminRolesController : Controller
	{


		private ApplicationDbContext _context;

		public AdminRolesController()
		{
			_context = new ApplicationDbContext();
		}


		[HttpGet]
		public ActionResult ViewAllRole()
		{
			var roles = _context.Roles.ToList();
			return View(roles);
		}

		public ActionResult ViewAllAccount()
		{
			var usersWithRoles = 	(from user in _context.Users
														select new
														{
															UserId = user.Id,
															Username = user.UserName,
															Email = user.Email,
															RoleNames = 
															(from userRole in user.Roles
															 join role in _context.Roles on userRole.RoleId
															equals role.Id
															select role.Name).ToList()
														})
														.ToList()
														.Select(p => new UserInRolesViewModel()
														{
															UserId = p.UserId,
															Username = p.Username,
															Email = p.Email,
															Role = string.Join(",", p.RoleNames)

														});
			return View(usersWithRoles);
		}


		public ActionResult Index()
		{
			return View();
		}
	}
}