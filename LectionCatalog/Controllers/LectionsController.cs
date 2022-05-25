using LectionCatalog.Data.Services;
using LectionCatalog.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LectionCatalog.Controllers
{
    public class LectionsController : Controller
    {
        private readonly ILectionsService _service;
        public LectionsController(ILectionsService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index(FilterVM filterVM)
        {
            var allLections = await _service.GetAllAsync();
            var lectionsDropdownData = await _service.GetLectionDropdownsValues();

            FilterVM filterLections = new FilterVM()
            {
                Lections = (List<Models.Lection>)allLections,
                LectionDropdownsVM = lectionsDropdownData
            };

            if (!string.IsNullOrEmpty(filterVM.SelectedLector))
            {
                filterLections.Lections = (List<Models.Lection>)await _service.GetLectorsFilter(filterVM.SelectedLector);
            }

            if (filterVM.SelectedYear != 0)
            {
                filterLections.Lections = (List<Models.Lection>)_service.GetYearFilter(filterLections.Lections, filterVM.SelectedYear);
            }

            if (!string.IsNullOrEmpty(filterVM.SelectedCategory))
            {
                filterLections.Lections = (List<Models.Lection>)_service.GetCategoryFilter(filterLections.Lections, filterVM.SelectedCategory);
            }

            if (!string.IsNullOrEmpty(filterVM.SelectedFilter))
            {
                filterLections.Lections = (List<Models.Lection>)_service.GetFilterTypes(filterLections.Lections, filterVM.SelectedFilter);
            }

            ViewBag.selectedLector = filterVM.SelectedLector != null ? filterVM.SelectedLector : "Lectors";
            ViewBag.selectedYear = filterVM.SelectedYear != 0 ? filterVM.SelectedYear.ToString() : "Year";
            ViewBag.selectedCategory = filterVM.SelectedCategory != null ? filterVM.SelectedCategory : "Category";
            ViewBag.selectedFilter = filterVM.SelectedFilter != null ? filterVM.SelectedFilter : "Filter";

            return View(filterLections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lectionDetails = await _service.GetLectionByIdAsync(id);
            return View(lectionDetails);
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
                LectionCategory = lectionDetails.LectionCategory,
                Country = lectionDetails.Country,
                LectorIds = lectionDetails.Lectors_Lections.Select(n => n.LectorId).ToList()
            };

            var movieDropdownData = await _service.GetLectionDropdownsValues();

            ViewBag.LectorsSelectList = new SelectList(movieDropdownData.Lectors, "Id", "FullName");

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

        public async Task<IActionResult> Search(string name)
        {
            var allLections = await _service.SearchAsync(name);
            return PartialView(allLections);
        }
    }
}
