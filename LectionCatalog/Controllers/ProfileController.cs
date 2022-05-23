using LectionCatalog.Data.Services;
using LectionCatalog.Data.ViewModels;
using LectionCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LectionCatalog.Controllers
{
	public class ProfileController : Controller
	{
		private static bool _editAccess;
		private ILectionsService _service;
		private readonly UserManager<ApplicationUser> _userManager;

		public ProfileController(ILectionsService service, UserManager<ApplicationUser> userManager)
        {
			_service = service;
			_userManager = userManager;
        }
		public IActionResult Index()
		{
			string userName = HttpContext.User.Identity.Name;

			var user = _userManager.FindByNameAsync(userName).Result;

			var newUser = new EditAccountVM()
			{
				UserName = user.FullName,
				EmailAddress = user.Email,
			};


			EditAccess();

			return View(newUser);
		}

		public void EditAccess()
		{
			_editAccess = _editAccess ? true : false;
			ViewBag.EditAccess = _editAccess;

		}

		public async Task<IActionResult> Favorite()
        {
			var lections = await _service.GetFavoriteLections();

			return View(lections);
        }
		public async Task<IActionResult> WatchLater()
		{
			var lections = await _service.GetWatchLaterLections();

			return View(lections);
		}
		public IActionResult History()
		{
			return View();
		}
	}
}
