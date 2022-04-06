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

        public async Task<IActionResult> Index()
        {
            var allLections = await _service.GetAllAsync();

            var lectionsDropdownData = await _service.GetLectionDropdownsValues();
            ViewBag.Lectors = lectionsDropdownData.Lectors;
            ViewBag.LectionsCategory = lectionsDropdownData.LectionsCategory;
            return View(allLections);
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
                ImageURL = lectionDetails.ImageURL,
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
    }
}
