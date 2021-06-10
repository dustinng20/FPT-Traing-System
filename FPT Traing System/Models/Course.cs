using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.Models
{
	public class Course
	{
	
		[Required]
		public int CourseId { get; set; }
	
		
		[Required]
		public int Id { get; set; }
		
		
		[Required]
		public string Name { get; set; }
	
		
		[Required]

		public string Description { get; set; }
	}
}