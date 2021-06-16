using FPT_Traing_System.Models;
using FPT_Traing_System.viewModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
    public class EnrollmentTrainersController : Controller
    {
		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;



		public EnrollmentTrainersController()
		{
			_context = new ApplicationDbContext();
			_userManager = new UserManager<ApplicationUser>(
			 new UserStore<ApplicationUser>(new ApplicationDbContext()));

		}

		[Authorize(Roles = "staff")]
		[HttpGet]
		public ActionResult Index()
		{

			var courses = _context.Courses.ToList();

			return View(courses);
		}



		[HttpGet]
		public ActionResult AssignTrainer(int id)
		{
			var users = _context.Users.ToList();

			var usersInCourse = _context.EnrollmentTrainers
				.Where(a => a.CourseId == id)
				.Select(a => a.User)
				.ToList();

			var viewmodel = new EnrollmentTrainerViewModel();

			if (usersInCourse == null)
			{
				viewmodel.CourseId = id;
				viewmodel.Users = users;


				return View(viewmodel);
			}



			var usersWithUserRole = new List<ApplicationUser>();

			foreach (var trainer in users)
			{
				if (_userManager.GetRoles(trainer.Id)[0].Equals("trainer")
					&& !usersInCourse.Contains(trainer)
					)
				{
					usersWithUserRole.Add(trainer);
				}
			}

			var viewModel = new EnrollmentTrainerViewModel
			{
				CourseId = id,
				Users = usersWithUserRole
			};

			return View(viewModel);
		}
		[Authorize(Roles = "staff")]



		[HttpPost]
		public ActionResult AssignTrainer(EnrollmentTrainer model)
		{
			var enrollmentTrainer = new EnrollmentTrainer
			{
				CourseId = model.CourseId,
				UserId = model.UserId
			};

			if (enrollmentTrainer == null) return HttpNotFound();
			_context.EnrollmentTrainers.Add(enrollmentTrainer);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult CourseTrainer(int? id)
		{

			var users = _context.EnrollmentTrainers
				.Where(t => t.CourseId == id)
				.Select(t => t.User)
				.ToList();

			ViewBag.CourseId = id;

			return View(users);
		}



		[HttpGet]
		public ActionResult RemoveTrainer(int? id, string userId)
		{

			var enrollmentTrainer = _context.EnrollmentTrainers
				.SingleOrDefault(t => t.CourseId == id && t.UserId == userId);

			if (enrollmentTrainer == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			_context.EnrollmentTrainers.Remove(enrollmentTrainer);
			_context.SaveChanges();

			return RedirectToAction("CourseTrainer", new { id = id });
		}

	}
}