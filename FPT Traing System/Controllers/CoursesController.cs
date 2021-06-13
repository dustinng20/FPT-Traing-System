using FPT_Traing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{

	public class CoursesController : Controller
	{


		private ApplicationDbContext _context;


		public CoursesController()
		{
			_context = new ApplicationDbContext();
		}


		public ActionResult Index()
		{
			var courses = _context.Courses.ToList();

			return View(courses);
		}


		[HttpGet]
		public ActionResult Create()
		{
			return View();
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
				Category = course.Category,
				Description = course.Description
			};


			_context.Courses.Add(newCourse);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}




		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();
			var category = _context.Courses.SingleOrDefault(c => c.Id == id);
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
	}
}