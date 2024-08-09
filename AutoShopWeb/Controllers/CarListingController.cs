using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using AutoShop.Utility;
using AutoShopWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var CarListings = _carListingService.CarListings
                .Where(c => c.UserId == userId)
                .Select(c => new CarListingVM
                {
                    Car = c
                })
                .ToList();

            CarListings.Sort(new CarListingsStatusComparer());

            return View(CarListings);
        }

        // Returns the page for adding new car listings
        public IActionResult Create()
        {
            CarListingVM carListing = new()
            {
                EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                {
                    Text = et.Type,
                    Value = et.EngineTypeId.ToString()
                }),

                TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                {
                    Text = tt.Type,
                    Value = tt.TransmissionTypeId.ToString()
                }),

                FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                {
                    Text = ft.Type,
                    Value = ft.FuelTypeId.ToString()
                }),

                BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                {
                    Text = bt.Type,
                    Value = bt.BodyTypeId.ToString()
                }),

                ModelOptions = _modelService.Models.Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.ModelId.ToString()
                }),

                BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.BrandId.ToString()
                }),

                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            return View(carListing);
        }


        // Handles the post request with the new car listing
        [HttpPost]
        public IActionResult Create(CarListingVM CarListing, IEnumerable<IFormFile> files)
        {
            if (ModelState.IsValid && files != null && files.Any())
            {
                bool vinExists = _carListingService.VINExists(CarListing.Car.VIN, CarListing.Car.CarId);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    CarListing.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                    {
                        Text = et.Type,
                        Value = et.EngineTypeId.ToString()
                    });

                    CarListing.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                    {
                        Text = tt.Type,
                        Value = tt.TransmissionTypeId.ToString()
                    });

                    CarListing.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                    {
                        Text = ft.Type,
                        Value = ft.FuelTypeId.ToString()
                    });

                    CarListing.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                    {
                        Text = bt.Type,
                        Value = bt.BodyTypeId.ToString()
                    });

                    CarListing.ModelOptions = _modelService.Models.Select(m => new SelectListItem
                    {
                        Text = m.Name,
                        Value = m.ModelId.ToString()
                    });

                    CarListing.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.BrandId.ToString()
                    });
                    return View(CarListing);
                }

                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string imagePath = Path.Combine(wwwRootPath, @"images\car");
                var images = new List<Image>();

                foreach(var file in files)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    using (var fileStream = new FileStream(Path.Combine(imagePath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    var image = new Image
                    {
                        ImageUrl = "/images/car/" + fileName,
                        CarId = CarListing.Car.CarId,
                        CarListing = CarListing.Car
                    };

                    images.Add(image);
                }

                CarListing.Car.UserId = CarListing.UserId;
                CarListing.Car.Status = CarStatus.Active;
                CarListing.Car.Images = images;
                _carListingService.Add(CarListing.Car);
                TempData["success"] = "New car listing added successfully.";
                return RedirectToAction("Index");
            }
            else if (files == null || files.Count() < 1)
            {
                ModelState.AddModelError("Car.Images", "You must upload at least 5 images of the car.");
                CarListing.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                {
                    Text = et.Type,
                    Value = et.EngineTypeId.ToString()
                });

                CarListing.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                {
                    Text = tt.Type,
                    Value = tt.TransmissionTypeId.ToString()
                });

                CarListing.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                {
                    Text = ft.Type,
                    Value = ft.FuelTypeId.ToString()
                });

                CarListing.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                {
                    Text = bt.Type,
                    Value = bt.BodyTypeId.ToString()
                });

                CarListing.ModelOptions = _modelService.Models.Select(m => new SelectListItem
                {
                    Text = m.Name,
                    Value = m.ModelId.ToString()
                });

                CarListing.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                {
                    Text = b.Name,
                    Value = b.BrandId.ToString()
                });
                return View(CarListing);
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

            CarListing? CarListingFromDb = _carListingService.Get(id);
            if (CarListingFromDb == null)
            {
                return NotFound();
            }

            // Retrieve logged-in user's ID
            var loggedInUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Check if the logged-in user owns this car listing
            if (CarListingFromDb.UserId != loggedInUserId)
            {
                // If the logged-in user doesn't own this car listing, prevent editing
                return Unauthorized();
            }

            var EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            var TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            var FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            var BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            var ModelOptions = _modelService.Models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            var BrandOptions = _brandService.Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });

            var viewModel = new CarListingVM
            {
                BrandOptions = BrandOptions,
                ModelOptions = ModelOptions,
                EngineTypeOptions = EngineTypeOptions,
                FuelTypeOptions = FuelTypeOptions,
                TransmissionTypeOptions = TransmissionTypeOptions,
                BodyTypeOptions = BodyTypeOptions,
                Car = CarListingFromDb,
                UserId = loggedInUserId
            };

            return View(viewModel);
        }


        // Handles the post request with the updated car listing
        [HttpPost]
        public IActionResult Edit(CarListingVM CarListing, IEnumerable<IFormFile>? newImages, string? removedImageIds)
        {
            if (ModelState.IsValid)
            {
                bool vinExists = _carListingService.VINExists(CarListing.Car.VIN, CarListing.Car.CarId);
                if (vinExists)
                {
                    ModelState.AddModelError("Car.VIN", "This VIN already exists. Please provide a different VIN.");
                    CarListing.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                    {
                        Text = et.Type,
                        Value = et.EngineTypeId.ToString()
                    });

                    CarListing.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                    {
                        Text = tt.Type,
                        Value = tt.TransmissionTypeId.ToString()
                    });

                    CarListing.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                    {
                        Text = ft.Type,
                        Value = ft.FuelTypeId.ToString()
                    });

                    CarListing.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                    {
                        Text = bt.Type,
                        Value = bt.BodyTypeId.ToString()
                    });

                    CarListing.ModelOptions = _modelService.Models.Select(m => new SelectListItem
                    {
                        Text = m.Name,
                        Value = m.ModelId.ToString()
                    });

                    CarListing.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.BrandId.ToString()
                    });

                    CarListing.Car.Images = _imageService.ImagesOfCar(CarListing.Car.CarId).ToList();

                    return View(CarListing);
                }

                var imagesOfTheCar = _imageService.ImagesOfCar(CarListing.Car.CarId).ToList();
                var imagesToRemove = removedImageIds?.Split(',', StringSplitOptions.RemoveEmptyEntries);
                if ((newImages != null && newImages.Any() && (imagesOfTheCar.Count + newImages.Count()) - imagesToRemove?.Length < 1) || ((newImages == null || !newImages.Any()) && imagesOfTheCar.Count - imagesToRemove?.Length < 1))
                {
                    ModelState.AddModelError("Car.Images", "You cant remove all the images of the car, there has to be at least 1 image of the car.");
                    CarListing.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
                    {
                        Text = et.Type,
                        Value = et.EngineTypeId.ToString()
                    });

                    CarListing.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
                    {
                        Text = tt.Type,
                        Value = tt.TransmissionTypeId.ToString()
                    });

                    CarListing.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
                    {
                        Text = ft.Type,
                        Value = ft.FuelTypeId.ToString()
                    });

                    CarListing.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
                    {
                        Text = bt.Type,
                        Value = bt.BodyTypeId.ToString()
                    });

                    CarListing.ModelOptions = _modelService.Models.Select(m => new SelectListItem
                    {
                        Text = m.Name,
                        Value = m.ModelId.ToString()
                    });

                    CarListing.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
                    {
                        Text = b.Name,
                        Value = b.BrandId.ToString()
                    });

                    CarListing.Car.Images = _imageService.ImagesOfCar(CarListing.Car.CarId).ToList();

                    return View(CarListing);
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
                            CarId = CarListing.Car.CarId,
                            CarListing = CarListing.Car
                        };

                        images.Add(image);
                    }

                    CarListing.Car.Images = images;
                }

                if (!string.IsNullOrEmpty(removedImageIds))
                {
                    foreach(var imageId in imagesToRemove)
                    {
                        var image = _imageService.Get(int.Parse(imageId));
                        if(image != null)
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

                CarListing.Car.UserId = CarListing.UserId;
                CarListing.Car.Status = CarStatus.Active;
                _carListingService.Update(CarListing.Car);
                TempData["success"] = "Car listing updated successfully.";
                return RedirectToAction("Index");
            }

            CarListing.EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            CarListing.TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            CarListing.FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            CarListing.BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            CarListing.ModelOptions = _modelService.Models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            CarListing.BrandOptions = _brandService.Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });

            CarListing.Car.Images = _imageService.ImagesOfCar(CarListing.Car.CarId).ToList();

            return View(CarListing);
        }

        // Returns the page for archiving car listings
        public IActionResult Archive(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            CarListing? CarListingFromDb = _carListingService.Get(id);
            if (CarListingFromDb == null)
            {
                return NotFound();
            }

            var EngineTypeOptions = _engineTypeService.EngineTypes.Select(et => new SelectListItem
            {
                Text = et.Type,
                Value = et.EngineTypeId.ToString()
            });

            var TransmissionTypeOptions = _transmissionTypeService.TransmissionTypes.Select(tt => new SelectListItem
            {
                Text = tt.Type,
                Value = tt.TransmissionTypeId.ToString()
            });

            var FuelTypeOptions = _fuelTypeService.FuelTypes.Select(ft => new SelectListItem
            {
                Text = ft.Type,
                Value = ft.FuelTypeId.ToString()
            });

            var BodyTypeOptions = _bodyTypeService.BodyTypes.Select(bt => new SelectListItem
            {
                Text = bt.Type,
                Value = bt.BodyTypeId.ToString()
            });

            var ModelOptions = _modelService.Models.Select(m => new SelectListItem
            {
                Text = m.Name,
                Value = m.ModelId.ToString()
            });

            var BrandOptions = _brandService.Brands.Select(b => new SelectListItem
            {
                Text = b.Name,
                Value = b.BrandId.ToString()
            });

            var viewModel = new CarListingVM
            {
                BrandOptions = BrandOptions,
                ModelOptions = ModelOptions,
                EngineTypeOptions = EngineTypeOptions,
                FuelTypeOptions = FuelTypeOptions,
                TransmissionTypeOptions = TransmissionTypeOptions,
                BodyTypeOptions = BodyTypeOptions,
                Car = CarListingFromDb
            };

            return View(viewModel);
        }

        // Handles the post request with the car listing that is supposed to be archived
        [HttpPost]
        public IActionResult Archive(CarListingVM CarListing)
        {
            if (CarListing.Car == null || CarListing.Car.CarId == 0)
            {
                return NotFound();
            }

            _carListingService.Archive(CarListing.Car.CarId);
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
