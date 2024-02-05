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
        public IActionResult Index(int BrandId)
        {
            ViewBag.BrandId = BrandId;
            var modelsOfBrand = _modelService.Models.Where(m => m.BrandId ==  BrandId).ToList();
            return View(modelsOfBrand);
        }

        // Returns the page for adding new models for a brand
        public IActionResult Create(int BrandId)
        {
            ViewData["BrandId"] = BrandId;
            return View();
        }

        // Handles the post request with the new models
        [HttpPost]
        public IActionResult Create(Model Model)
        {
            if (ModelState.IsValid)
            {
                Model.BrandId = Convert.ToInt32(Request.Form["BrandId"]);
                _modelService.Add(Model);
                TempData["success"] = "New model added successfully.";
                return RedirectToAction("Index", new { BrandId = Model.BrandId });
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
            Model ModelFromDb = _modelService.Get(id);
            if (ModelFromDb == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = ModelFromDb.BrandId;
            return View(ModelFromDb);
        }

        // Handles the post request with the updated model
        [HttpPost]
        public IActionResult Edit(Model Model)
        {
            if (ModelState.IsValid)
            {
                _modelService.Update(Model);
                TempData["success"] = "Model updated successfully.";
                return RedirectToAction("Index", new { BrandId = Model.BrandId });
            }
            return View(Model);
        }


        // Returns the page for removing models of a brand
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            Model? ModelFromDb = _modelService.Get(id);
            if (ModelFromDb == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = ModelFromDb.BrandId;
            return View(ModelFromDb);
        }


        // Handles the post request with the model that is supposed to be removed from a brand
        [HttpPost]
        public IActionResult Delete(Model Model)
        {
            _modelService.Delete(Model);
            TempData["success"] = "Model removed successfully.";
            return RedirectToAction("Index", new { BrandId = Model.BrandId });
        }
    }
}
