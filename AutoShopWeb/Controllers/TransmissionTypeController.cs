﻿using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class TransmissionTypeController : Controller
    {
        private readonly ITransmissionTypeService _transmissionTypeServices;

        public TransmissionTypeController(ITransmissionTypeService transmissionTypeServices)
        {
            _transmissionTypeServices = transmissionTypeServices;
        }

        // Returns all the transmission types
        public IActionResult Index()
        {
            return View(_transmissionTypeServices.TransmissionTypes);
        }

        // Returns the page for adding new transmission types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new transmission type
        [HttpPost]
        public IActionResult Create(TransmissionType transmissionType)
        {
            if (ModelState.IsValid)
            {
                _transmissionTypeServices.Add(transmissionType);
                TempData["success"] = "New transmission type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing transmission types
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            TransmissionType? transmissionTypeFromDb = _transmissionTypeServices.Get(id);
            if (transmissionTypeFromDb == null)
            {
                return NotFound();
            }

            return View(transmissionTypeFromDb);
        }

        // Handles the post request with the updated transmission type
        [HttpPost]
        public IActionResult Edit(TransmissionType transmissionType)
        {
            if (ModelState.IsValid)
            {
                _transmissionTypeServices.Update(transmissionType);
                TempData["success"] = "Transmission type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing transmission types
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            TransmissionType? transmissionTypeFromDb = _transmissionTypeServices.Get(id);
            if (transmissionTypeFromDb == null)
            {
                return NotFound();
            }

            return View(transmissionTypeFromDb);
        }

        // Handles the post request with the transmission type that is supposed to be removed
        [HttpPost]
        public IActionResult Delete(TransmissionType transmissionType)
        {
            _transmissionTypeServices.Delete(transmissionType);
            TempData["success"] = "Transmission type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
