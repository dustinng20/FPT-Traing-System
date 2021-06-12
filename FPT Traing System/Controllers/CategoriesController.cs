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
		private List<Category> _categories = new List<Category>();

		public CategoriesController()
		{
			_categories.Add(new Category()
			{
				Id = 1,
				Name = "Family",
				Description = "Buy Milk",
			});

			_categories.Add(new Category()
			{
				Id = 2,
				Name = "Professional",
				Description = "Report the Progress of the Project",
			});

		}

		public ActionResult Create()
		{
			return View();
		}


		public ActionResult Edit()
		{
			return View();
		}


		public ActionResult Delete()
		{
			return View();
		}


		public ActionResult Index()
		{
			return View(_categories);
		}
	}
}