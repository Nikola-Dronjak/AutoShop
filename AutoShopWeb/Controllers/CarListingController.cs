using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using AutoShop.Utility;
using AutoShopWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.User_Role)]
    public class CarListingController : Controller
    {
        private readonly ICarListingService _carListingService;
        private readonly IEngineTypeService _engineTypeService;
        private readonly ITransmissionTypeService _transmissionTypeService;
        private readonly IFuelTypeService _fuelTypeService;
        private readonly IBodyTypeService _bodyTypeService;
        private readonly IModelService _modelService;
        private readonly IBrandService _brandService;
        private readonly IImageService _imageService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarListingController(ICarListingService carListingService, IEngineTypeService engineTypeService, ITransmissionTypeService transmissionTypeService, IFuelTypeService fuelTypeService, IBodyTypeService bodyTypeService, IModelService modelService, IBrandService brandService, IImageService imageService, IWebHostEnvironment webHostEnvironment)
        {
            _carListingService = carListingService;
            _engineTypeService = engineTypeService;
            _transmissionTypeService = transmissionTypeService;
            _fuelTypeService = fuelTypeService;
            _bodyTypeService = bodyTypeService;
            _modelService = modelService;
            _brandService = brandService;
            _imageService = imageService;
            _webHostEnvironment = webHostEnvironment;
        }

        // Returns all the car listings
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var carListings = _carListingService.CarListings.Where(c => c.UserId == userId).Select(c => new CarListingVM { Car = c }).ToList();
            carListings.Sort(new CarListingsStatusComparer());
            return View(carListings);
        }

        // Returns the page for adding new car listings
        public IActionResult Create()
        {
            CarListingVM carListing = new()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
            return View(carListing);
        }

        // Handles the post request with the new car listing
        [HttpPost]
        public IActionResult Create(CarListingVM carListing, IEnumerable<IFormFile> files)
        {
            if (ModelState.IsValid && files != null && files.Any())
            {
                bool vinExists = _carListingService.VINExists(carListing.Car.VIN, carListing.Car.CarId);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
                    return View(carListing);
                }

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string imagePath = Path.Combine(wwwRootPath, @"images\car");
                var images = new List<Image>();

                foreach (var file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    var image = new Image
                    {
                        ImageUrl = "/images/car/" + fileName,
                        CarId = carListing.Car.CarId,
                        CarListing = carListing.Car
                    };

                    images.Add(image);
                }

                carListing.Car.UserId = carListing.UserId;
                carListing.Car.Status = CarStatus.Active;
                carListing.Car.Images = images;
                _carListingService.Add(carListing.Car);
                TempData["success"] = "New car listing added successfully.";
                return RedirectToAction("Index");
            }
            else if (files == null || files.Count() < 5)
            {
                ModelState.AddModelError("Car.Images", "You must upload at least 5 images of the car.");
                DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
                return View(carListing);
            }
            return View();
        }

        // Returns the page for updating new car listings
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            CarListing? carListingFromDb = _carListingService.Get(id);
            if (carListingFromDb == null)
            {
                return NotFound();
            }

            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (carListingFromDb.UserId != loggedInUserId)
            {
                return Unauthorized();
            }

            CarListingVM carListing = new()
            {
                Car = carListingFromDb,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
            return View(carListing);
        }

        // Handles the post request with the updated car listing
        [HttpPost]
        public IActionResult Edit(CarListingVM carListing, IEnumerable<IFormFile>? newImages, string? removedImageIds)
        {
            if (ModelState.IsValid)
            {
                bool vinExists = _carListingService.VINExists(carListing.Car.VIN, carListing.Car.CarId);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
                    carListing.Car.Images = _imageService.ImagesOfCar(carListing.Car.CarId).ToList();
                    return View(carListing);
                }

                var imagesOfTheCar = _imageService.ImagesOfCar(carListing.Car.CarId).ToList();
                var imagesToRemove = removedImageIds?.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if ((newImages != null && newImages.Any() && (imagesOfTheCar.Count + newImages.Count()) - imagesToRemove?.Length < 1) || ((newImages == null || !newImages.Any()) && imagesOfTheCar.Count - imagesToRemove?.Length < 1))
                {
                    ModelState.AddModelError("Car.Images", "You cant remove all the images of the car, there has to be at least 1 image of the car.");
                    DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
                    carListing.Car.Images = _imageService.ImagesOfCar(carListing.Car.CarId).ToList();
                    return View(carListing);
                }

                if (newImages != null && newImages.Count() > 0)
                {
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string productPath = Path.Combine(wwwRootPath, @"images\car");
                    var images = new List<Image>();

                    foreach (var file in newImages)
                    {
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                        }

                        var image = new Image
                        {
                            ImageUrl = "/images/car/" + fileName,
                            CarId = carListing.Car.CarId,
                            CarListing = carListing.Car
                        };

                        images.Add(image);
                    }

                    carListing.Car.Images = images;
                }

                if (!string.IsNullOrEmpty(removedImageIds))
                {
                    foreach (var imageId in imagesToRemove)
                    {
                        var image = _imageService.Get(int.Parse(imageId));
                        if (image != null)
                        {
                            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, image.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }

                            _imageService.Delete(image);
                        }
                    }
                }

                carListing.Car.UserId = carListing.UserId;
                carListing.Car.Status = CarStatus.Active;
                _carListingService.Update(carListing.Car);
                TempData["success"] = "Car listing updated successfully.";
                return RedirectToAction("Index");
            }

            DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
            carListing.Car.Images = _imageService.ImagesOfCar(carListing.Car.CarId).ToList();
            return View(carListing);
        }

        // Returns the page for archiving car listings
        public IActionResult Archive(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            CarListing? carListingFromDb = _carListingService.Get(id);
            if (carListingFromDb == null)
            {
                return NotFound();
            }

            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (carListingFromDb.UserId != loggedInUserId)
            {
                return Unauthorized();
            }

            CarListingVM carListing = new()
            {
                Car = carListingFromDb,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            DropdownHelper.PopulateDropdown(carListing, _engineTypeService, _transmissionTypeService, _fuelTypeService, _bodyTypeService, _modelService, _brandService);
            return View(carListing);
        }

        // Handles the post request with the car listing that is supposed to be archived
        [HttpPost]
        public IActionResult Archive(CarListingVM carListing)
        {
            if (carListing.Car == null || carListing.Car.CarId == 0)
            {
                return NotFound();
            }

            _carListingService.Archive(carListing.Car.CarId);
            TempData["success"] = "Car listing archived successfully.";
            return RedirectToAction("Index");
        }

        // Fetches models from the database based off of selected brand
        [HttpGet("GetModelsByBrand")]
        public IActionResult GetModelsByBrand(int brandId)
        {
            var models = _modelService.Models.Where(m => m.BrandId == brandId).ToList();
            return Json(models.Select(m => new { ModelId = m.ModelId, Name = m.Name }));
        }
    }
}
