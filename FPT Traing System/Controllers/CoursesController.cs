using FPT_Traing_System.Models;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FPT_Traing_System.viewModel;

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
		public ActionResult Index(string searchString)
		{
			var coursesInDb = _context.Courses

				.Include(c => c.Category)
				.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				coursesInDb = _context.Courses.Where(c => c.Name.Contains(searchString)).ToList();
			}

			return View(coursesInDb);
		}


		[HttpGet]
		public ActionResult Create()
		{
			var viewModel = new CourseCategoriesViewModel()
			{
				Categories = _context.Categories.ToList()
			};
			return View(viewModel);
		}

		[HttpPost]
		public ActionResult Create(Course course)
		{


			if (!ModelState.IsValid)
			{
				return View(course);
			}


			var newCourse = new Course()
			{
				Name = course.Name,
				CategoryId = course.CategoryId,
				Description = course.Description
			};


			_context.Courses.Add(newCourse);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}




		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();
			var category = _context.Courses

				.Include(c => c.Category)
				.SingleOrDefault(c => c.Id == id);
			if (category == null) return HttpNotFound();

			return View(category);
		}


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
		public ActionResult Edit(Course course)
		{
			var courseInDb = _context.Courses.SingleOrDefault(c => c.Id == course.Id);
			if (courseInDb == null) return HttpNotFound();

			courseInDb.Name = course.Name;
			courseInDb.Description = course.Description;
			courseInDb.Category = course.Category;


			_context.SaveChanges();

			return RedirectToAction("Index");
		}
	}
}