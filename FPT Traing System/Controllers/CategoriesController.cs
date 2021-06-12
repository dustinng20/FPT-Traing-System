using FPT_Traing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
	public class CategoriesController : Controller
	{
		// GET: Categories
		private ApplicationDbContext _context;

		public CategoriesController()
		{
			_context = new ApplicationDbContext(); //use adbc class to connect database
		}

		public ActionResult Index()
		{
			var categories = _context.Categories.ToList();
			return View(categories);
		}


		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();
			var category = _context.Categories.SingleOrDefault(t => t.Id == id);
			if (category == null) return HttpNotFound();

			return View(category);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}


		[HttpPost]
		public ActionResult Create(Category category)
		{
			var newCategory = new Category()
			{
				Name = category.Name,
				Description = category.Description
			};

			_context.Categories.Add(newCategory);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}



		public ActionResult Edit()
		{
			return View();
		}




		public ActionResult Delete(int? id)
		{
			if (id == null) return HttpNotFound();
		
			var category = _context.Categories.SingleOrDefault(t => t.Id == id);
		
			if (category == null) return HttpNotFound();
			
			_context.Categories.Remove(category);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}



	}
}