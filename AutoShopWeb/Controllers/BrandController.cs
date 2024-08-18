using AutoShop.Commands.BrandCommands;
using AutoShop.Domain;
using AutoShop.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.Admin_Role)]
    public class BrandController : Controller
    {
        private readonly IMediator _mediator;

        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // Returns all the brands
        public async Task<IActionResult> Index()
        {
            var query = new GetAllBrandsQuery();
            IEnumerable<Brand> brands = await _mediator.Send(query);
            return View(brands);
        }

        // Returns the page for adding new brands
        public IActionResult Create()
        {
            return View();
        }

        // Handles the post request with the new brands
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var command = new CreateBrandCommand(brand);
                await _mediator.Send(command);
                TempData["success"] = "New brand added successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for updating existing brands
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetBrandByIdQuery(id);
            Brand brandFromDb = await _mediator.Send(query);
            if (brandFromDb == null)
            {
                return NotFound();
            }

            return View(brandFromDb);
        }

        // Handles the post request with the updated brand
        [HttpPost]
        public async Task<IActionResult> Edit(Brand brand)
        {
            if (ModelState.IsValid)
            {
                var command = new UpdateBrandCommand(brand);
                await _mediator.Send(command);
                TempData["success"] = "Brand updated successfully.";
                return RedirectToAction("Index");
            }

            return View();
        }

        // Returns the page for removing brands
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetBrandByIdQuery(id);
            Brand brandFromDb = await _mediator.Send(query);
            if (brandFromDb == null)
            {
                return NotFound();
            }

            return View(brandFromDb);
        }

        // Handles the post request with the brand that is supposed to be removed
        [HttpPost]
        public async Task<IActionResult> Delete(Brand brand)
        {
            var command = new DeleteBrandCommand(brand);
            await _mediator.Send(command);
            TempData["success"] = "Brand removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
