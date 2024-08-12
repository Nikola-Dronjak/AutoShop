using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        // Returns all the brands
        public IActionResult Index()
        {
            return View(_brandService.Brands);
        }

        // Returns the page for adding new brands
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new brands
        [HttpPost]
        public IActionResult Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.Add(brand);
                TempData["success"] = "New brand added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing brands
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Brand? brandFromDb = _brandService.Get(id);
            if (brandFromDb == null)
            {
                return NotFound();
            }

            return View(brandFromDb);
        }

        // Handles the post request with the updated brand
        [HttpPost]
        public IActionResult Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _brandService.Update(brand);
                TempData["success"] = "Brand updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing brands
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            Brand? brandFromDb = _brandService.Get(id);
            if (brandFromDb == null)
            {
                return NotFound();
            }

            return View(brandFromDb);
        }

        // Handles the post request with the brand that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(Brand brand)
        {
            _brandService.Delete(brand);
            TempData["success"] = "Brand removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
