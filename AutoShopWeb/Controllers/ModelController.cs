using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class ModelController : Controller
    {
        private readonly IModelService _modelService;

        public ModelController(IModelService modelService)
        {
            _modelService = modelService;
        }

        // Returns all the models for a specific brand
        public IActionResult Index(int brandId)
        {
            ViewBag.BrandId = brandId;
            var modelsOfBrand = _modelService.Models.Where(m => m.BrandId == brandId).ToList();
            return View(modelsOfBrand);
        }

        // Returns the page for adding new models for a brand
        public IActionResult Create(int brandId)
        {
            ViewData["BrandId"] = brandId;
            return View();
        }

        // Handles the post request with the new models
        [HttpPost]
        public IActionResult Create(Model model)
        {
            if (ModelState.IsValid)
            {
                model.BrandId = Convert.ToInt32(Request.Form["BrandId"]);
                _modelService.Add(model);
                TempData["success"] = "New model added successfully.";
                return RedirectToAction("Index", new { BrandId = model.BrandId });
            }

            return View();
        }

        // Returns the page for updating existing models of a brand
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Model modelFromDb = _modelService.Get(id);
            if (modelFromDb == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = modelFromDb.BrandId;
            return View(modelFromDb);
        }

        // Handles the post request with the updated model
        [HttpPost]
        public IActionResult Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                _modelService.Update(model);
                TempData["success"] = "Model updated successfully.";
                return RedirectToAction("Index", new { BrandId = model.BrandId });
            }

            return View(model);
        }

        // Returns the page for removing models of a brand
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Model? modelFromDb = _modelService.Get(id);
            if (modelFromDb == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = modelFromDb.BrandId;
            return View(modelFromDb);
        }

        // Handles the post request with the model that is supposed to be removed from a brand
        [HttpPost]
        public IActionResult Delete(Model model)
        {
            _modelService.Delete(model);
            TempData["success"] = "Model removed successfully.";
            return RedirectToAction("Index", new { BrandId = model.BrandId });
        }
    }
}
