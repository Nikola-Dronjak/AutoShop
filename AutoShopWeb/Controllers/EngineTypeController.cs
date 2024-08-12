using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class EngineTypeController : Controller
    {
        private readonly IEngineTypeService _engineTypeService;

        public EngineTypeController(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        // Returns all the body types
        public IActionResult Index()
        {
            return View(_engineTypeService.EngineTypes);
        }

        // Returns the page for adding new engine types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new engine type
        [HttpPost]
        public IActionResult Create(EngineType engineType)
        {
            if (ModelState.IsValid)
            {
                _engineTypeService.Add(engineType);
                TempData["success"] = "New engine type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing engine types
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            EngineType? engineTypeFromDb = _engineTypeService.Get(id);
            if (engineTypeFromDb == null)
            {
                return NotFound();
            }

            return View(engineTypeFromDb);
        }

        // Handles the post request with the updated engine type
        [HttpPost]
        public IActionResult Edit(EngineType engineType)
        {
            if (ModelState.IsValid)
            {
                _engineTypeService.Update(engineType);
                TempData["success"] = "Engine type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing engine types
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            EngineType? engineTypeFromDb = _engineTypeService.Get(id);
            if (engineTypeFromDb == null)
            {
                return NotFound();
            }

            return View(engineTypeFromDb);
        }

        // Handles the post request with the engine type that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(EngineType engineType)
        {
            _engineTypeService.Delete(engineType);
            TempData["success"] = "Engine type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
