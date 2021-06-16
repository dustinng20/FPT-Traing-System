using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.Models
{
	public class EnrollmentTrainee
	{
		[Key]
		[Column(Order = 1)] //2key
		[ForeignKey("User")]
		public string UserId { get; set; }
		public ApplicationUser User { get; set; }


		[Column(Order = 2)] //2key
		[ForeignKey("Category")]
		[Required]
		public int CategoryId { get; set; } // forgein key
		public Category Category { get; set; } //linking object


		[Key]
		[Column(Order = 3)]
		[ForeignKey("Course")]
		public int CourseId { get; set; }
		public Course Course { get; set; }
	}
}