using FPT_Traing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
	public class StaffRolesController : Controller
	{
		// GET: StaffRoles

		private ApplicationDbContext _context;

		public StaffRolesController()
		{
			_context = new ApplicationDbContext();
		}
		public ActionResult Index()
		{
			return View();
		}
	}
}