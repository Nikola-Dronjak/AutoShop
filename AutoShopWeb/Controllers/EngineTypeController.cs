using AutoShop.Commands.EngineTypeCommands;
using AutoShop.Domain;
using AutoShop.Queries.EngineTypeQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class EngineTypeController : Controller
    {
        private readonly IMediator _mediator;

        public EngineTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the body types
        public async Task<IActionResult> Index()
        {
            var query = new GetAllEngineTypesQuery();
            IEnumerable<EngineType> engineTypes = await _mediator.Send(query);
            return View(engineTypes);
        }

        // Returns the page for adding new engine types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new engine type
        [HttpPost]
        public async Task<IActionResult> Create(EngineType engineType)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateEngineTypeCommand(engineType);
                await _mediator.Send(command);
                TempData["success"] = "New engine type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing engine types
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetEngineTypeByIdQuery(id);
            EngineType engineTypeFromDb = await _mediator.Send(query);
            if (engineTypeFromDb == null)
            {
                return NotFound();
            }

            return View(engineTypeFromDb);
        }

        // Handles the post request with the updated engine type
        [HttpPost]
        public async Task<IActionResult> Edit(EngineType engineType)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateEngineTypeCommand(engineType);
                await _mediator.Send(command);
                TempData["success"] = "Engine type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing engine types
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetEngineTypeByIdQuery(id);
            EngineType engineTypeFromDb = await _mediator.Send(query);
            if (engineTypeFromDb == null)
            {
                return NotFound();
            }

            return View(engineTypeFromDb);
        }

        // Handles the post request with the engine type that is supposed to be removed
        [HttpPost]
        public async Task<IActionResult> Delete(EngineType engineType)
        {
            var command = new DeleteEngineTypeCommand(engineType);
            await _mediator.Send(command);
            TempData["success"] = "Engine type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
