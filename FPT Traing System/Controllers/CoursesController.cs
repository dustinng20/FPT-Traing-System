using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
    public class CoursesController : Controller
    {
		// GET: Courses
		    public CoursesController()
		    {
        
		    }
        public ActionResult Index()
        {
            return View();
        }
    }
}