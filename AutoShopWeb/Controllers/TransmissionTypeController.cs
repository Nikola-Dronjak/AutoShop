using AutoShop.Commands.TransmissionTypeCommands;
using AutoShop.Domain;
using AutoShop.Queries.TransmissionTypeQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class TransmissionTypeController : Controller
    {
        private readonly IMediator _mediator;

        public TransmissionTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the transmission types
        public async Task<IActionResult> Index()
        {
            var query = new GetAllTransmissionTypesQuery();
            IEnumerable<TransmissionType> transmissionTypes = await _mediator.Send(query);
            return View(transmissionTypes);
        }

        // Returns the page for adding new transmission types
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new transmission type
        [HttpPost]
        public async Task<IActionResult> Create(TransmissionType transmissionType)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateTransmissionTypeCommand(transmissionType);
                await _mediator.Send(command);
                TempData["success"] = "New transmission type added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing transmission types
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetTransmissionTypeByIdQuery(id);
            TransmissionType transmissionTypeFromDb = await _mediator.Send(query);
            if (transmissionTypeFromDb == null)
            {
                return NotFound();
            }

            return View(transmissionTypeFromDb);
        }

        // Handles the post request with the updated transmission type
        [HttpPost]
        public async Task<IActionResult> Edit(TransmissionType transmissionType)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateTransmissionTypeCommand(transmissionType);
                await _mediator.Send(command);
                TempData["success"] = "Transmission type updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing transmission types
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetTransmissionTypeByIdQuery(id);
            TransmissionType transmissionTypeFromDb = await _mediator.Send(query);
            if (transmissionTypeFromDb == null)
            {
                return NotFound();
            }

            return View(transmissionTypeFromDb);
        }

        // Handles the post request with the transmission type that is supposed to be removed
        [HttpPost]
        public async Task<IActionResult> Delete(TransmissionType transmissionType)
        {
            var command = new DeleteTransmissionTypeCommand(transmissionType);
            await _mediator.Send(command);
            TempData["success"] = "Transmission type removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
