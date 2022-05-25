﻿using LectionCatalog.Data;
using LectionCatalog.Data.Services;
using LectionCatalog.Data.ViewModels;
using LectionCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace LectionCatalog.Controllers
{
	public class ProfileController : Controller
	{
		private static bool _editAccess;
		private ILectionsService _service;
		private readonly UserManager<ApplicationUser> _userManager;
		private ApplicationUser user;

		public ProfileController(ILectionsService service, UserManager<ApplicationUser> userManager,
			AppDbContext context)
        {
			_service = service;
			_userManager = userManager;	
		}
		public IActionResult Index()
		{
			CheckUserName();

			var newUser = new EditAccountVM()
			{
				UserName = user.FullName,
				EmailAddress = user.Email,
			};

			//_userManager.UpdateAsync(user);
			
			//EditAccess();

			return View(newUser);
		}

		[HttpGet]
		public async Task<JsonResult> addFavorite(int LectionId)
        {
			CheckUserName();

            if (!user.Favorites.Contains(LectionId.ToString()))
            {
				user.Favorites += LectionId.ToString() + " ";
				var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
					return Json("Lection was added to Favorite list");
				}
			}
			return Json("It has already been added");
        }

		public async Task<JsonResult> addWatchLater(int LectionId)
		{
			CheckUserName();

			if (!user.WatchLater.Contains(LectionId.ToString()))
			{
				user.WatchLater += LectionId.ToString() + " ";
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return Json("Lection was added to Watch later list");
				}
			}
			return Json("It has already been added");
		}

		public async Task<JsonResult> addHistory(int LectionId)
		{
			CheckUserName();

			if (!user.History.Contains(LectionId.ToString()))
			{
				user.History += LectionId.ToString() + " ";
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return Json("Success");
				}
			}
			return Json("Something is wrong");
		}
		public async Task<JsonResult> delFavorite(int lectionId, int eq)
        {
			CheckUserName();

			if (user.Favorites.Contains(lectionId.ToString()))
			{
				var sub = lectionId.ToString() + " ";
				user.Favorites = user.Favorites.Replace(sub, "");
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return Json(eq);
				}
			}
			return Json("");
		}
		public async Task<IActionResult> Favorite()
        {
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.Favorites);
			ViewBag.Count = Count(lections);

			return View(lections);
        }
		public async Task<IActionResult> WatchLater()
		{
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.WatchLater);
			ViewBag.Count = Count(lections);

			return View(lections);
		}
		public async Task<IActionResult> History()
		{
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.History);
			ViewBag.Count = Count(lections);

			return View(lections);
		}
		public void CheckUserName()
		{
			if (user == null)
			{
				string userName = HttpContext.User.Identity.Name;
				user = _userManager.FindByNameAsync(userName).Result;
			}

			if (user.Favorites == null || user.Favorites == "0")
			{
				user.Favorites = "";
			}
			if (user.WatchLater == null || user.WatchLater == "0")
			{
				user.WatchLater = "";
			}
			if (user.History == null || user.History == "0")
			{
				user.History = "";
			}
		}
		public bool Count(IEnumerable lections)
		{
			foreach (var item in lections)
			{
				return true;
			}
			return false;
		}

	}
}