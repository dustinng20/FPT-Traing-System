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
	public class EnrollmentTraineesController : Controller
	{

		private ApplicationDbContext _context;
		private UserManager<ApplicationUser> _userManager;



		public EnrollmentTraineesController()
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
		public ActionResult AssignTrainee(int id)
		{
			var users = _context.Users.ToList();

			var usersInCourse = _context.EnrollmentTrainees
				.Where(a => a.CourseId == id)
				.Select(a => a.User)
				.ToList();

			var viewmodel = new EnrollmentTraineeViewModel();

			if (usersInCourse == null)
			{
				viewmodel.CourseId = id;
				viewmodel.Users = users;


				return View(viewmodel);
			}



			var usersWithUserRole = new List<ApplicationUser>();

			foreach (var trainee in users)
			{
				if (_userManager.GetRoles(trainee.Id)[0].Equals("trainee")
					&& !usersInCourse.Contains(trainee)
					)
				{
					usersWithUserRole.Add(trainee);
				}
			}

			var viewModel = new EnrollmentTraineeViewModel
			{
				CourseId = id,
				Users = usersWithUserRole
			};

			return View(viewModel);
		}
		[Authorize(Roles = "staff")]



		[HttpPost]
		public ActionResult AssignTrainee(EnrollmentTrainee model)
		{
			var enrollmentTrainee = new EnrollmentTrainee
			{
				CourseId = model.CourseId,
				UserId = model.UserId
			};

			if (enrollmentTrainee == null) return HttpNotFound();
			_context.EnrollmentTrainees.Add(enrollmentTrainee);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpGet]
		public ActionResult CourseTrainee(int? id)
		{

			var users = _context.EnrollmentTrainees
				.Where(t => t.CourseId == id)
				.Select(t => t.User)
				.ToList();

			ViewBag.CourseId = id;

			return View(users);
		}



		[HttpGet]
		public ActionResult RemoveTrainee(int? id, string userId)
		{

			var EnrollmentTrainer = _context.EnrollmentTrainers
				.SingleOrDefault(t => t.CourseId == id && t.UserId == userId);

			if (EnrollmentTrainer == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

			_context.EnrollmentTrainers.Remove(EnrollmentTrainer);
			_context.SaveChanges();

			return RedirectToAction("CourseTrainee", new { id = id });
		}


		[Authorize(Roles = "trainee")]
		public ActionResult MineTrainer()
		{
			var userId = User.Identity.GetUserId();

			var courses = _context.EnrollmentTrainers
				.Where(t => t.UserId.Equals(userId))
				.Select(t => t.Course)
				.ToList();

			return View(courses);
		}
	}
}