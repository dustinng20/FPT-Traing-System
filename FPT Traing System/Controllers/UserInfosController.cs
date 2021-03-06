using FPT_Traing_System.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FPT_Traing_System.Controllers
{
	[Authorize]
	public class UserInfosController : Controller
	{
		private ApplicationDbContext _context;
		public UserInfosController()
		{
			_context = new ApplicationDbContext();
		}

		public ActionResult Index()
		{
			var userId = User.Identity.GetUserId();
			var userInfo = _context.UserInfos.SingleOrDefault(u => u.UserId.Equals(userId));

			if (userInfo == null) return HttpNotFound();
			return View(userInfo);
		}


		[HttpGet]
		public ActionResult Edit()
		{
			var userId = User.Identity.GetUserId();
			var userInfo = _context.UserInfos.SingleOrDefault(u => u.UserId.Equals(userId));

			if (userInfo == null) return HttpNotFound();
			return View(userInfo);
		}

		[HttpPost]
		public ActionResult Edit(UserInfo userInfo)
		{
			if (!ModelState.IsValid)
			{
				return View(userInfo);
			}
			var userInfoInDb = _context.UserInfos.SingleOrDefault(u => u.UserId.Equals(userInfo.UserId));

			if (userInfoInDb == null) return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

			userInfoInDb.FullName = userInfo.FullName;
			userInfoInDb.Phone = userInfo.Phone;

			_context.SaveChanges();

			return RedirectToAction("Index");
		}



	}
}