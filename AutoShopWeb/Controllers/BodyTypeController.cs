using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class BodyTypeController : Controller
    {
        private readonly IBodyTypeService _bodyTypeServices;

        public BodyTypeController(IBodyTypeService bodyTypeServices)
        {
            _bodyTypeServices = bodyTypeServices;
        }

        // Returns all the body types
        public IActionResult Index()
        {
            return View(_bodyTypeServices.BodyTypes);
        }

        // Returns the page for adding new body types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new body type
        [HttpPost]
        public IActionResult Create(BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                _bodyTypeServices.Add(bodyType);
                TempData["success"] = "New body type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing body types
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            BodyType? bodyTypeFromDb = _bodyTypeServices.Get(id);
            if (bodyTypeFromDb == null)
            {
                return NotFound();
            }

            return View(bodyTypeFromDb);
        }

        // Handles the post request with the updated body type
        [HttpPost]
        public IActionResult Edit(BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                _bodyTypeServices.Update(bodyType);
                TempData["success"] = "Body type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing body types
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            BodyType? bodyTypeFromDb = _bodyTypeServices.Get(id);
            if (bodyTypeFromDb == null)
            {
                return NotFound();
            }

            return View(bodyTypeFromDb);
        }

        // Handles the post request with the body type that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(BodyType bodyType)
        {
            _bodyTypeServices.Delete(bodyType);
            TempData["success"] = "Body type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
