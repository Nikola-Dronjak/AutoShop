using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using AutoShop.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace AutoShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarListingService _carListingService;
        private readonly IEngineTypeService _engineTypeService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;
        private readonly UserManager<IdentityUser> _userManager;
        public HomeController(ILogger<HomeController> logger, ICarListingService carListingService, IEngineTypeService engineTypeService, ITransmissionTypeService transmissionTypeService, IBodyTypeService bodyTypeService, IFuelTypeService fuelTypeService, IModelService modelService, IBrandService brandService, UserManager<IdentityUser> userManager)
        {
            _logger = logger;
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
                PageIndex = page
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
            if (!ModelState.IsValid)
            {
                // Repopulate dropdowns with available options if ModelState is invalid
                searchCriteria.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                {
                    Text = et.Type,
                    Value = et.EngineTypeId.ToString()
                });

                searchCriteria.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                {
                    Text = tt.Type,
                    Value = tt.TransmissionTypeId.ToString()
                });

                searchCriteria.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                {
                    Text = ft.Type,
                    Value = ft.FuelTypeId.ToString()
                });

                searchCriteria.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                {
                    Text = bt.Type,
                    Value = bt.BodyTypeId.ToString()
                });

                searchCriteria.ModelOptions = _modelService.Models.Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.ModelId.ToString()
                });

                searchCriteria.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.BrandId.ToString()
                });

                return View("_SearchBar", searchCriteria);
            }

            const int PageSize = 10;

            // Apply filtering based on the search criteria
            var filteredCarListings = _carListingService.FilterCarListings(searchCriteria);

            // Get paginated results based on the filtered data
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // Fetches models from the database based off of selected brand
        [HttpGet("GetModelsByBrandSearch")]
        public IActionResult GetModelsByBrand(int brandId)
        {
            var models = _modelService.Models.Where(m => m.BrandId == brandId).ToList();
            return Json(models.Select(m => new { ModelId = m.ModelId, Name = m.Name }));
        }
    }
}