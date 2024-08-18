using AutoShop.Commands.CarListingCommands;
using AutoShop.Commands.ImageCommands;
using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Queries.ImageQueries;
using AutoShop.Queries.ModelQueries;
using AutoShop.Utility;
using AutoShopWeb.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

#pragma warning disable CS8604 // Possible null reference argument.
#pragma warning disable CS8602 // Possible null reference argument.
namespace AutoShopWeb.Controllers
{
    [Authorize(Roles = UserRole.User_Role)]
    public class CarListingController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarListingController(IMediator mediator, IWebHostEnvironment webHostEnvironment)
        {
            _mediator = mediator;
            _webHostEnvironment = webHostEnvironment;
        }

        // Returns all the car listings
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var query = new GetAllCarListingsQuery();
            IEnumerable<CarListing> carListings = await _mediator.Send(query);
            var carListingVMs = carListings.Where(c => c.UserId == userId).Select(c => new CarListingVM { Car = c }).ToList();
            carListingVMs.Sort(new CarListingsStatusComparer());
            return View(carListingVMs);
        }

        // Returns the page for adding new car listings
        public async Task<IActionResult> Create()
        {
            CarListingVM carListing = new()
            {
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            await DropdownHelper.PopulateDropdown(carListing, _mediator);
            return View(carListing);
        }

        // Handles the post request with the new car listing
        [HttpPost]
        public async Task<IActionResult> Create(CarListingVM carListing, IEnumerable<IFormFile> files)
        {
            if (ModelState.IsValid && files != null && files.Count() >= 5)
            {
                var checkVINQuery = new CheckVINExistsQuery(carListing.Car.VIN, carListing.Car.CarId);
                bool vinExists = await _mediator.Send(checkVINQuery);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    await DropdownHelper.PopulateDropdown(carListing, _mediator);
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
                var createCommand = new CreateCarListingCommand(carListing.Car);
                await _mediator.Send(createCommand);
                TempData["success"] = "New car listing added successfully.";
                return RedirectToAction("Index");
            }
            else if (files == null || files.Count() < 5)
            {
                ModelState.AddModelError("Car.Images", "You must upload at least 5 images of the car.");
                await DropdownHelper.PopulateDropdown(carListing, _mediator);
                return View(carListing);
            }
            return View();
        }

        // Returns the page for updating new car listings
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetCarListingByIdQuery(id);
            CarListing carListingFromDb = await _mediator.Send(query);
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

            await DropdownHelper.PopulateDropdown(carListing, _mediator);
            return View(carListing);
        }

        // Handles the post request with the updated car listing
        [HttpPost]
        public async Task<IActionResult> Edit(CarListingVM carListing, IEnumerable<IFormFile>? newImages, string? removedImageIds)
        {
            if (ModelState.IsValid)
            {
                var checkVINQuery = new CheckVINExistsQuery(carListing.Car.VIN, carListing.Car.CarId);
                bool vinExists = await _mediator.Send(checkVINQuery);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    await DropdownHelper.PopulateDropdown(carListing, _mediator);
                    IEnumerable<Image> imagesOfCar = await _mediator.Send(new GetAllImagesByCarIdQuery(carListing.Car.CarId));
                    carListing.Car.Images = imagesOfCar.ToList();
                    return View(carListing);
                }

                IEnumerable<Image> imagesQuery = await _mediator.Send(new GetAllImagesByCarIdQuery(carListing.Car.CarId));
                var imagesOfTheCar = imagesQuery.ToList();
                var imagesToRemove = removedImageIds?.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if ((newImages != null && newImages.Any() && (imagesOfTheCar.Count + newImages.Count()) - imagesToRemove?.Length < 5) || ((newImages == null || !newImages.Any()) && imagesOfTheCar.Count - imagesToRemove?.Length < 5))
                {
                    ModelState.AddModelError("Car.Images", "You cant remove all the images of the car, there have to be at least 5 image of the car.");
                    await DropdownHelper.PopulateDropdown(carListing, _mediator);
                    carListing.Car.Images = imagesQuery.ToList();
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
                        var query = new GetImageByIdQuery(int.Parse(imageId));
                        Image image = await _mediator.Send(query);
                        if (image != null)
                        {
                            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, image.ImageUrl.TrimStart('/'));
                            if (System.IO.File.Exists(filePath))
                            {
                                System.IO.File.Delete(filePath);
                            }

                            var deleteCommand = new DeleteImageCommand(image);
                            await _mediator.Send(deleteCommand);
                        }
                    }
                }

                carListing.Car.UserId = carListing.UserId;
                carListing.Car.Status = CarStatus.Active;
                var updateCommand = new UpdateCarListingCommand(carListing.Car);
                await _mediator.Send(updateCommand);
                TempData["success"] = "Car listing updated successfully.";
                return RedirectToAction("Index");
            }

            await DropdownHelper.PopulateDropdown(carListing, _mediator);
            IEnumerable<Image> imagesFromDb = await _mediator.Send(new GetAllImagesByCarIdQuery(carListing.Car.CarId));
            carListing.Car.Images = imagesFromDb.ToList();
            return View(carListing);
        }

        // Returns the page for archiving car listings
        public async Task<IActionResult> Archive(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var query = new GetCarListingByIdQuery(id);
            CarListing carListingFromDb = await _mediator.Send(query);
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

            await DropdownHelper.PopulateDropdown(carListing, _mediator);
            return View(carListing);
        }

        // Handles the post request with the car listing that is supposed to be archived
        [HttpPost]
        public async Task<IActionResult> Archive(CarListingVM carListing)
        {
            if (carListing.Car == null || carListing.Car.CarId == 0)
            {
                return NotFound();
            }

            var archiveCommand = new ArchiveCarListingCommand(carListing.Car.CarId);
            await _mediator.Send(archiveCommand);
            TempData["success"] = "Car listing archived successfully.";
            return RedirectToAction("Index");
        }

        // Fetches models from the database based off of selected brand
        [HttpGet("GetModelsByBrand")]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var query = new GetAllModelsQuery();
            IEnumerable<Model> models = await _mediator.Send(query);
            var modelsOfBrand = models.Where(m => m.BrandId == brandId).ToList();
            return Json(modelsOfBrand.Select(m => new { ModelId = m.ModelId, Name = m.Name }));
        }
    }
}
