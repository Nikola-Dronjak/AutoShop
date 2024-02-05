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
        public IActionResult Create(FuelType FuelType)
        {
            if (ModelState.IsValid)
            {
                _fuelTypeServices.Add(FuelType);
                TempData["success"] = "New fuel type added successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Returns the page for updating existing fuel types
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            FuelType? FuelTypeFromDb = _fuelTypeServices.Get(id);
            if (FuelTypeFromDb == null)
            {
                return NotFound();
            }
            return View(FuelTypeFromDb);
        }


        // Handles the post request with the updated fuel type
        [HttpPost]
        public IActionResult Edit(FuelType FuelType)
        {
            if (ModelState.IsValid)
            {
                _fuelTypeServices.Update(FuelType);
                TempData["success"] = "Fuel type updated successfully.";
                return RedirectToAction("Index");
            }
            return View();
        }

        // Returns the page for removing fuel types
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            FuelType? FuelTypeFromDb = _fuelTypeServices.Get(id);
            if (FuelTypeFromDb == null)
            {
                return NotFound();
            }
            return View(FuelTypeFromDb);
        }


        // Handles the post request with the fuel type that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(FuelType FuelType)
        {
            _fuelTypeServices.Delete(FuelType);
            TempData["success"] = "Fuel type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
