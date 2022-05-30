using LectionCatalog.Data;
using LectionCatalog.Data.Services;
using LectionCatalog.Data.ViewModels;
using LectionCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Claims;
using System.Collections.Generic;

namespace LectionCatalog.Controllers
{
	public class ProfileController : Controller
	{
		private ILectionsService _service;
		private readonly UserManager<ApplicationUser> _userManager;
		private ApplicationUser user;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ProfileController(ILectionsService service, UserManager<ApplicationUser> userManager,
			IHttpContextAccessor httpContextAccessor)
        {
			_httpContextAccessor = httpContextAccessor;
			_service = service;
			_userManager = userManager;	
		}
		public IActionResult Index()
		{
			CheckUserName();

			var newUser = new EditAccountVM()
			{
				FullName = user.FullName,
				Email = user.Email,
			};
			ViewBag.BottomSet = 0;

			return View(newUser);
		}

		[HttpPost]
		public async Task<IActionResult> Index(EditAccountVM editAccountVM)
        {
			CheckUserName();
			ViewBag.BottomSet = 0;

			if (!ModelState.IsValid)
			{
				return View(editAccountVM);
			}

			user.FullName = editAccountVM.FullName;
			user.Email = editAccountVM.Email;

			var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
				return View(editAccountVM);
			}

			return View("Error");

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
		public async Task<JsonResult> delWatchLater(int lectionId, int eq)
		{
			CheckUserName();

			if (user.WatchLater.Contains(lectionId.ToString()))
			{
				var sub = lectionId.ToString() + " ";
				user.WatchLater = user.WatchLater.Replace(sub, "");
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return Json(eq);
				}
			}
			return Json("");
		}
		public async Task<JsonResult> delHistory(int lectionId, int eq)
		{
			CheckUserName();

			if (user.History.Contains(lectionId.ToString()))
			{
				var sub = lectionId.ToString() + " ";
				user.History = user.History.Replace(sub, "");
				var result = await _userManager.UpdateAsync(user);

				if (result.Succeeded)
				{
					return Json(eq);
				}
			}
			return Json("");
		}
		public async Task<JsonResult> delAllRecords(int type)
		{
			CheckUserName();

			switch (type)
			{
				case 0: user.Favorites = "";break;
				case 1: user.WatchLater = "";break;
				case 2: user.History = "";break;
			}
			
			var result = await _userManager.UpdateAsync(user);

			return Json("");
		}
		public async Task<IActionResult> Favorite()
        {
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.Favorites);
			ViewBag.Count = Count(lections);
			ViewBag.BottomSet = 1;

			return View(lections);
        }
		public async Task<IActionResult> WatchLater()
		{
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.WatchLater);
			ViewBag.Count = Count(lections);
			ViewBag.BottomSet = 2;

			return View(lections);
		}
		public async Task<IActionResult> History()
		{
			CheckUserName();

			var lections = await _service.GetLectionsByList(user.History);
			ViewBag.Count = Count(lections);
			ViewBag.BottomSet = 3;

			return View(lections);
		}
		public async void CheckUserName()
		{
			if (user == null)
			{
				//var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
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
