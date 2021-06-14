using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FPT_Traing_System.Models
{
	public class UserInfo
	{
		[Key]
		[ForeignKey("User")]
		public string UserId { get; set; }

		public ApplicationUser User { get; set; }

		[Required]
		public string FullName { get; set; }

		[Required(ErrorMessage = "Required")]
		[RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
		[DisplayName("Phone Number")]
		public string Phone { get; set; }
	}
}