using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class FuelTypeController : Controller
    {
        private readonly IFuelTypeService _fuelTypeServices;

        public FuelTypeController(IFuelTypeService fuelTypeServices)
        {
            _fuelTypeServices = fuelTypeServices;
        }

        // Returns all the body types
        public IActionResult Index()
        {
            return View(_fuelTypeServices.FuelTypes);
        }

        // Returns the page for adding new fuel types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new fuel type
        [HttpPost]
        public IActionResult Create(FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                _fuelTypeServices.Add(fuelType);
                TempData["success"] = "New fuel type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing fuel types
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            FuelType? fuelTypeFromDb = _fuelTypeServices.Get(id);
            if (fuelTypeFromDb == null)
            {
                return NotFound();
            }

            return View(fuelTypeFromDb);
        }

        // Handles the post request with the updated fuel type
        [HttpPost]
        public IActionResult Edit(FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                _fuelTypeServices.Update(fuelType);
                TempData["success"] = "Fuel type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing fuel types
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            FuelType? fuelTypeFromDb = _fuelTypeServices.Get(id);
            if (fuelTypeFromDb == null)
            {
                return NotFound();
            }

            return View(fuelTypeFromDb);
        }

        // Handles the post request with the fuel type that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(FuelType fuelType)
        {
            _fuelTypeServices.Delete(fuelType);
            TempData["success"] = "Fuel type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
