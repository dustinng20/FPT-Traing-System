using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.Models
{
	public class Course
	{
		[Required]
		[Key]
		public int Id { get; set; }


		[Required]
		public string Category { get; set; }


		[Required]
		[DisplayName("Course Name")]
		public string Name { get; set; }


		[Required]
		public string Description { get; set; }
	}
}