using LectionCatalog.Data.Services;
using LectionCatalog.Data.Static;
using LectionCatalog.Data.ViewModels;
using LectionCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ReflectionIT.Mvc.Paging;

namespace LectionCatalog.Controllers
{
    public class LectionsController : Controller
    {
        private readonly ILectionsService _service;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly int PAGESIZE;
        public LectionsController(ILectionsService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
            PAGESIZE = 12;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FilterVM filterVM, int page = 1, bool filt = false, string sLector = "", string sYear = "", string sCategory = "", string sFilter = "")
        {
            var allLections = await _service.GetAllAsync();
            var lectionsDropdownData = await _service.GetLectionDropdownsValues();
            var btnClose = false;

			if (filt)
			{
                filterVM.SelectedLector = sLector == "Lectors"? null: sLector;
                filterVM.SelectedYear = sYear == "Year"? 0 : int.Parse(sYear);
                filterVM.SelectedCategory = sCategory == "Category"? null: sCategory;
                filterVM.SelectedFilter = sFilter == "Filter"? null: sFilter;
			}

            if (!string.IsNullOrEmpty(filterVM.SelectedLector))
            {
                allLections = (List<Models.Lection>)await _service.GetLectorsFilter(filterVM.SelectedLector);
                btnClose = true;
            }

            if (filterVM.SelectedYear != 0)
            {
                allLections = (List<Models.Lection>)_service.GetYearFilter(allLections, filterVM.SelectedYear);
                btnClose = true;
            }

            if (!string.IsNullOrEmpty(filterVM.SelectedCategory))
            {
                allLections = (List<Models.Lection>)_service.GetCategoryFilter(allLections, filterVM.SelectedCategory);
                btnClose = true;
            }

            if (!string.IsNullOrEmpty(filterVM.SelectedFilter))
            {
                allLections = (List<Models.Lection>)_service.GetFilterTypes(allLections, filterVM.SelectedFilter);
                btnClose = true;
            }

            ViewBag.selectedLector = filterVM.SelectedLector != null ? filterVM.SelectedLector : "Lectors";
            ViewBag.selectedYear = filterVM.SelectedYear != 0 ? filterVM.SelectedYear.ToString() : "Year";
            ViewBag.selectedCategory = filterVM.SelectedCategory != null ? filterVM.SelectedCategory : "Category";
            ViewBag.selectedFilter = filterVM.SelectedFilter != null ? filterVM.SelectedFilter : "Filter";
            ViewBag.buttonClose = btnClose? "block": "none";

            IEnumerable<Lection> lectionsPerPages = allLections.Skip((page - 1) * PAGESIZE).Take(PAGESIZE);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = PAGESIZE, TotalItems = allLections.Count };

            FilterVM filterLections = new FilterVM()
            {
                Lections = lectionsPerPages,
                PageInfo = pageInfo,
                LectionDropdownsVM = lectionsDropdownData
            };

            return View(filterLections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lectionDetails = await _service.GetLectionByIdAsync(id);
            return View(lectionDetails);
        }

        public async Task<JsonResult> Delete(int id)
        {
            await _service.DeleteLectionAsync(id);

            string userName = HttpContext.User.Identity.Name;
            var user = _userManager.FindByNameAsync(userName).Result;

            user.Favorites = fwhReplace(user.Favorites, id);
            user.WatchLater = fwhReplace(user.WatchLater, id);
            user.History = fwhReplace(user.History, id);

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return Json("");
            }
            return Json("");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var lectionDetails = await _service.GetLectionByIdAsync(id);
            if (lectionDetails == null)
            {
                return View("NotFound");
            }

            var response = new NewLectionVM()
            {
                Id = lectionDetails.Id,
                Name = lectionDetails.Name,
                Description = lectionDetails.Description,  
                Year = lectionDetails.Year,
                Duration = lectionDetails.Duration,
                LinkURL = lectionDetails.LinkURL,
                Views = lectionDetails.Views,
                LectionCategory = lectionDetails.LectionCategory,
                Country = lectionDetails.Country,
                LectorIds = lectionDetails.Lectors_Lections.Select(n => n.LectorId).ToList()
            };

            var movieDropdownData = await _service.GetLectionDropdownsValues();

            ViewBag.LectorsSelectList = new SelectList(movieDropdownData.Lectors, "Id", "FullName");
            ViewBag.Id = response.Id;
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewLectionVM lection)
        {
            if (id != lection.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                var lectionDropdownData = await _service.GetLectionDropdownsValues();

                ViewBag.LectorsSelectList = new SelectList(lectionDropdownData.Lectors, "Id", "FullName");

                return View(lection);
            }

            await _service.UpdateLectionAsync(lection);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Create()
        {
            var lectionDropdownData = await _service.GetLectionDropdownsValues();

            ViewBag.LectorsSelectList = new SelectList(lectionDropdownData.Lectors, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewLectionVM lection)
        {
            if (!ModelState.IsValid)
            {
                var lectionDropdownData = await _service.GetLectionDropdownsValues();

                ViewBag.LectorsSelectList = new SelectList(lectionDropdownData.Lectors, "Id", "FullName");

                return View(lection);
            }

            await _service.AddNewLectionAsync(lection);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CreateStuffLection()
        {
            var lection = new NewLectionVM()
            {
                Name = "New world",
                Year = 2012,
                Description = "It's just a test.",
                LinkURL = "https://www.youtube.com/watch?v=AxLlcmWBKR8",
                Duration = 120,
                Country = Data.Enum.CountriesCategory.China,
                LectionCategory = Data.Enum.LectionCategory.Technology,
                Views = 10000000,
                LectorIds = new List<int>()
                {
                   3
                }
            };

            await _service.AddNewLectionAsync(lection);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Lectors()
        {
            var lectors = await _service.GetLectorsAsync();

            return View(lectors);
        }
        public async Task<IActionResult> Search(string name)
        {
            var allLections = await _service.SearchAsync(name);
            return PartialView(allLections);
        }

        public string fwhReplace(string list, int id)
        {
            if (list.Contains(id.ToString()))
            {
                var sub = id.ToString() + "";
                list = list.Replace(sub, "");
            }
            return list;
        }
    }
}
