using AutoShop.Commands.ModelCommands;
using AutoShop.Domain;
using AutoShop.Queries.ModelQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class ModelController : Controller
    {
        private readonly IMediator _mediator;

        public ModelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the models for a specific brand
        public async Task<IActionResult> Index(int brandId)
        {
            ViewBag.BrandId = brandId;
            var query = new GetAllModelsQuery();
            IEnumerable<Model> models = await _mediator.Send(query);
            var modelsOfBrand = models.Where(m => m.BrandId == brandId).ToList();
            return View(modelsOfBrand);
        }

        // Returns the page for adding new models for a brand
        public IActionResult Create(int brandId)
        {
            ViewData["BrandId"] = brandId;
            return View();
        }

        // Handles the post request with the new models
        [HttpPost]
        public async Task<IActionResult> Create(Model model)
        {
            if (ModelState.IsValid)
            {
                model.BrandId = Convert.ToInt32(Request.Form["BrandId"]);
                var command = new CreateModelCommand(model);
                await _mediator.Send(command);
                TempData["success"] = "New model added successfully.";
                return RedirectToAction("Index", new { BrandId = model.BrandId });
            }

            return View();
        }

        // Returns the page for updating existing models of a brand
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetModelByIdQuery(id);
            Model modelFromDb = await _mediator.Send(query);
            if (modelFromDb == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = modelFromDb.BrandId;
            return View(modelFromDb);
        }

        // Handles the post request with the updated model
        [HttpPost]
        public async Task<IActionResult> Edit(Model model)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateModelCommand(model);
                await _mediator.Send(command);
                TempData["success"] = "Model updated successfully.";
                return RedirectToAction("Index", new { BrandId = model.BrandId });
            }

            return View(model);
        }

        // Returns the page for removing models of a brand
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetModelByIdQuery(id);
            Model modelFromDb = await _mediator.Send(query);
            if (modelFromDb == null)
            {
                return NotFound();
            }

            ViewData["BrandId"] = modelFromDb.BrandId;
            return View(modelFromDb);
        }

        // Handles the post request with the model that is supposed to be removed from a brand
        [HttpPost]
        public async Task<IActionResult> Delete(Model model)
        {
            var command = new DeleteModelCommand(model);
            await _mediator.Send(command);
            TempData["success"] = "Model removed successfully.";
            return RedirectToAction("Index", new { BrandId = model.BrandId });
        }
    }
}
