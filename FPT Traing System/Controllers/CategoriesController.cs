using FPT_Traing_System.Models;
using Microsoft.Ajax.Utilities;
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

		[Authorize(Roles = "staff")]

		public ActionResult Index(string searchString)
		{
			var categoriesInDb = _context.Categories.ToList();

			if (!searchString.IsNullOrWhiteSpace())
			{
				categoriesInDb = _context.Categories.Where(t => t.Name.Contains(searchString)).ToList();
			}

			return View(categoriesInDb);
		}
		
		
		[Authorize(Roles = "staff")]


		public ActionResult Details(int? id)
		{
			if (id == null) return HttpNotFound();

			var category = _context.Categories.SingleOrDefault(t => t.Id == id);

			if (category == null) return HttpNotFound();

			return View(category);
		}


		[HttpGet]
		[Authorize(Roles = "staff")]

		public ActionResult Create()
		{
			return View();
		}


		[HttpPost]
		[Authorize(Roles = "staff")]

		public ActionResult Create(Category category)
		{
			if (!ModelState.IsValid)
			{
				return View(category);
			}

			var newCategory = new Category()
			{
				Name = category.Name,
				Description = category.Description
			};

			_context.Categories.Add(newCategory);
			_context.SaveChanges();

			return RedirectToAction("Index");
		}


		[HttpGet]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(int? id)
		{
			if (id == null) return HttpNotFound();

			var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
			if (categoryInDb == null) return HttpNotFound();

			return View(categoryInDb);
		}


		[HttpPost]
		[Authorize(Roles = "staff")]

		public ActionResult Edit(Category category)
		{
			var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);
			if (categoryInDb == null) return HttpNotFound();

			categoryInDb.Name = category.Name;
			categoryInDb.Description = category.Description;

			try
			{
				_context.SaveChanges();

			}
			catch (System.Data.Entity.Infrastructure.DbUpdateException)
			{
				ModelState.AddModelError("", "Category Name alreay exists");
				return View(category);
			}

			return RedirectToAction("Index");

		}



		[Authorize(Roles = "staff")]

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