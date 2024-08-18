using AutoShop.Commands.BodyTypeCommands;
using AutoShop.Domain;
using AutoShop.Queries.BodyTypeQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class BodyTypeController : Controller
    {
        private readonly IMediator _mediator;

        public BodyTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the body types
        public async Task<IActionResult> Index()
        {
            var query = new GetAllBodyTypesQuery();
            IEnumerable<BodyType> bodyTypes = await _mediator.Send(query);
            return View(bodyTypes);
        }

        // Returns the page for adding new body types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new body type
        [HttpPost]
        public async Task<IActionResult> Create(BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateBodyTypeCommand(bodyType);
                await _mediator.Send(command);
                TempData["success"] = "New body type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing body types
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetBodyTypeByIdQuery(id);
            BodyType bodyTypeFromDb = await _mediator.Send(query);
            if (bodyTypeFromDb == null)
            {
                return NotFound();
            }

            return View(bodyTypeFromDb);
        }

        // Handles the post request with the updated body type
        [HttpPost]
        public async Task<IActionResult> Edit(BodyType bodyType)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateBodyTypeCommand(bodyType);
                await _mediator.Send(command);
                TempData["success"] = "Body type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing body types
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetBodyTypeByIdQuery(id);
            BodyType bodyTypeFromDb = await _mediator.Send(query);
            if (bodyTypeFromDb == null)
            {
                return NotFound();
            }

            return View(bodyTypeFromDb);
        }

        // Handles the post request with the body type that is supposed to be removed
        [HttpPost]
        public async Task<IActionResult> Delete(BodyType bodyType)
        {
            var command = new DeleteBodyTypeCommand(bodyType);
            await _mediator.Send(command);
            TempData["success"] = "Body type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
