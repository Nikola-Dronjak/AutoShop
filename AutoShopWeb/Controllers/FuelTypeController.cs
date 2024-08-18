using AutoShop.Commands.FuelTypeCommands;
using AutoShop.Domain;
using AutoShop.Queries.FuelTypeQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class FuelTypeController : Controller
    {
        private readonly IMediator _mediator;

        public FuelTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the body types
        public async Task<IActionResult> Index()
        {
            var query = new GetAllFuelTypesQuery();
            IEnumerable<FuelType> fuelTypes = await _mediator.Send(query);
            return View(fuelTypes);
        }

        // Returns the page for adding new fuel types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new fuel type
        [HttpPost]
        public async Task<IActionResult> Create(FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateFuelTypeCommand(fuelType);
                await _mediator.Send(command);
                TempData["success"] = "New fuel type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing fuel types
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetFuelTypeByIdQuery(id);
            FuelType fuelTypeFromDb = await _mediator.Send(query);
            if (fuelTypeFromDb == null)
            {
                return NotFound();
            }

            return View(fuelTypeFromDb);
        }

        // Handles the post request with the updated fuel type
        [HttpPost]
        public async Task<IActionResult> Edit(FuelType fuelType)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateFuelTypeCommand(fuelType);
                await _mediator.Send(command);
                TempData["success"] = "Fuel type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing fuel types
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetFuelTypeByIdQuery(id);
            FuelType fuelTypeFromDb = await _mediator.Send(query);
            if (fuelTypeFromDb == null)
            {
                return NotFound();
            }

            return View(fuelTypeFromDb);
        }

        // Handles the post request with the fuel type that is supposed to be removed
        [HttpPost]
        public async Task<IActionResult> Delete(FuelType fuelType)
        {
            var command = new DeleteFuelTypeCommand(fuelType);
            await _mediator.Send(command);
            TempData["success"] = "Fuel type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
