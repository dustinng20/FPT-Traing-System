using FPT_Traing_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.viewModel
{
	public class EnrollmentTrainerViewModel
	{
		public int CourseId { get; set; }
		public int CategoryId { get; set; }

		public string UserId { get; set; }
		public IEnumerable<ApplicationUser> Users { get; set; }
	}
}