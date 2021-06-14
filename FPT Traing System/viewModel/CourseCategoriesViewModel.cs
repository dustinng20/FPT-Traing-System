using FPT_Traing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.viewModel
{
	public class CourseCategoriesViewModel
	{
		public Course Course { get; set; }

		public IEnumerable<Category> Categories { get; set; }
	}
}