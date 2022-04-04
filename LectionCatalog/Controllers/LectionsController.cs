using LectionCatalog.Data.Services;
using Microsoft.AspNetCore.Mvc;

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
            return View(allLections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var lectionDetails = await _service.GetLectionByIdAsync(id);
            return View(lectionDetails);
        }
    }
}
