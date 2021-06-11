using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.Models
{
	public class Category
	{
		[Required]
	//	[Key]
		public int Id { get; set; }

		[Required]
	//	[StringLength(225)]
	//	[DisplayName("Category Name")]
		//[Index("Name_Index", IsUnique = true)]
		public string Name { get; set; }
		
		[Required]
		public string Description { get; set; }
	}
}