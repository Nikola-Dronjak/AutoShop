using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Queries.ModelQueries;
using AutoShop.Utility;
using AutoShop.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

#pragma warning disable CS8604 // Possible null reference argument.
namespace AutoShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            const int PageSize = 10;

            var searchCriteria = new CarListingFilterVM();

            await DropdownHelper.PopulateDropdownFilter(searchCriteria, _mediator);

            var query = new GetPaginatedCarListingsQuery(page, PageSize);
            IEnumerable<CarListing> paginatedCarListings = await _mediator.Send(query);

            int totalPages = await _mediator.Send(new GetTotalPagesQuery(PageSize));
            var hasPreviousPage = page > 1;
            var hasNextPage = page < totalPages;

            var viewModel = new CarListingPaginationVM
            {
                CarListings = paginatedCarListings,
                TotalPages = totalPages,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                PageIndex = page,
                SearchCriteria = searchCriteria
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var query = new GetCarListingByIdQuery(id);
            CarListing carListingFromDb = await _mediator.Send(query);
            if (carListingFromDb == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(carListingFromDb.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var detailsViewModel = new CarListingDetailsVM
            {
                CarListing = carListingFromDb,
                UserEmail = user.Email,
                UserPhoneNumber = user.PhoneNumber
            };

            return View(detailsViewModel);
        }

        public async Task<IActionResult> Search(CarListingFilterVM searchCriteria, int page = 1)
        {
            await DropdownHelper.PopulateDropdownFilter(searchCriteria, _mediator);
            if (!ModelState.IsValid)
            {
                return View("_SearchBar", searchCriteria);
            }

            const int PageSize = 10;

            var query = new GetPaginatedCarListingsForFilteringsQuery(searchCriteria, page, PageSize);
            IEnumerable<CarListing> paginatedCarListings = await _mediator.Send(query);

            int totalPages = await _mediator.Send(new GetTotalPagesForFilteringQuery(searchCriteria, PageSize));
            var hasPreviousPage = page > 1;
            var hasNextPage = page < totalPages;

            var viewModel = new CarListingPaginationVM
            {
                CarListings = paginatedCarListings,
                TotalPages = totalPages,
                HasPreviousPage = hasPreviousPage,
                HasNextPage = hasNextPage,
                PageIndex = page,
                SearchCriteria = searchCriteria
            };

            return View("Index", viewModel);
        }

        // Fetches models from the database based off of selected brand
        [HttpGet("GetModelsByBrandSearch")]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var query = new GetAllModelsQuery();
            IEnumerable<Model> models = await _mediator.Send(query);
            var modelsOfBrand = models.Where(m => m.BrandId == brandId).ToList();
            return Json(modelsOfBrand.Select(m => new { ModelId = m.ModelId, Name = m.Name }));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}