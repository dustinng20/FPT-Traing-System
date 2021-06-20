using FPT_Traing_System.Models;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPT_Traing_System.viewModel;
using Microsoft.AspNet.Identity;

namespace FPT_Traing_System.Controllers
{

	public class CoursesController : Controller
	{


		private ApplicationDbContext _context;


		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}

		[HttpGet]
		[Authorize(Roles = "staff, trainer, trainee")]

		public ActionResult Index(string searchString)
		{
			var coursesInDb = _context.Courses.Include(c => c.Category)
				.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				coursesInDb = _context.Courses.Where(c => c.Name.Contains(searchString)).ToList();
			}

			return View(coursesInDb);
		}



		[HttpGet]
		[Authorize(Roles = "staff")]
		public ActionResult Create()
		{
			var viewModel = new CourseCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}

		[HttpPost]
		[Authorize(Roles = "staff")]
		public ActionResult Create(Course course)
		{
			if (!ModelState.IsValid)
			{
				var viewModels = new CourseCategoriesViewModel()
				{
					Course = course,
					Categories = _context.Categories.ToList()
				};

				return View(viewModels);
			}

			//var userId = User.Identity.GetUserId();
			var newCourse = new Course()
			{
				Description = course.Description,
				CategoryId = course.CategoryId,
				Name = course.Name,

			};

			_context.Courses.Add(newCourse);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}




		[Authorize(Roles = "staff, trainer, trainee")]

		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();
			var category = _context.Courses

				.Include(c => c.Category)
				.SingleOrDefault(c => c.Id == id);
			if (category == null) return HttpNotFound();

			return View(category);
		}

		[Authorize(Roles = "staff")]

		public ActionResult Delete(int? id)
		{
			if (id == null) return HttpNotFound();

			var course = _context.Courses.SingleOrDefault(c => c.Id == id);

			if (course == null) return HttpNotFound();

			_context.Courses.Remove(course);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpGet]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(int? id)
		{
			if (id == null) return HttpNotFound();

			var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == id);
			if (courseInDb == null) return HttpNotFound();

			var viewModel = new CourseCategoriesViewModel
			{
				Course = courseInDb,
				Categories = _context.Categories.ToList()
			};

			return View(viewModel);
		}


		[HttpPost]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(Course course)
		{
			var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == course.Id);
			if (courseInDb == null) return HttpNotFound();

			courseInDb.Name = course.Name;
			courseInDb.Description = course.Description;
			courseInDb.CategoryId = course.CategoryId;


			_context.SaveChanges();

			return RedirectToAction("Index");
		}

		
	}
}