using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using AutoShop.Utility;
using AutoShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

#pragma warning disable CS8604 // Possible null reference argument.
namespace AutoShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarListingService _carListingService;
        private readonly IEngineTypeService _engineTypeService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;
        private readonly UserManager<IdentityUser> _userManager;

        public HomeController(ICarListingService carListingService, IEngineTypeService engineTypeService, ITransmissionTypeService transmissionTypeService, IBodyTypeService bodyTypeService, IFuelTypeService fuelTypeService, IModelService modelService, IBrandService brandService, UserManager<IdentityUser> userManager)
        {
            _carListingService = carListingService;
            _engineTypeService = engineTypeService;
            _transmissionTypeService = transmissionTypeService;
            _bodyTypeService = bodyTypeService;
            _fuelTypeService = fuelTypeService;
            _modelService = modelService;
            _brandService = brandService;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1)
        {
            const int PageSize = 10;

            var searchCriteria = new CarListingFilterVM();

            DropdownHelper.PopulateDropdownFilter(searchCriteria, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);

            var paginatedCarListings = _carListingService.GetPaginatedCarListings(page, PageSize);
            var totalPages = _carListingService.GetTotalPages(PageSize);
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
            var Car = _carListingService.Get(id);
            if (Car == null)
            {
                return NotFound();
            }

            var user = await _userManager.FindByIdAsync(Car.UserId);
            if (user == null)
            {
                return NotFound();
            }

            var detailsViewModel = new CarListingDetailsVM
            {
                CarListing = Car,
                UserEmail = user.Email,
                UserPhoneNumber = user.PhoneNumber
            };

            return View(detailsViewModel);
        }

        public IActionResult Search(CarListingFilterVM searchCriteria, int page = 1)
        {
            DropdownHelper.PopulateDropdownFilter(searchCriteria, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
            if (!ModelState.IsValid)
            {
                return View("_SearchBar", searchCriteria);
            }

            const int PageSize = 10;

            var paginatedCarListings = _carListingService.GetPaginatedCarListingsForFiltering(searchCriteria, page, PageSize);
            var totalPages = _carListingService.GetTotalPagesForFiltering(searchCriteria, PageSize);
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
        public IActionResult GetModelsByBrand(int brandId)
        {
            var models = _modelService.Models.Where(m => m.BrandId == brandId).ToList();
            return Json(models.Select(m => new { ModelId = m.ModelId, Name = m.Name }));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}