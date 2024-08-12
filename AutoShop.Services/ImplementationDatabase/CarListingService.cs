using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using AutoShop.ViewModel;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class CarListingService : ICarListingService
    {
        private readonly IUnitOfWork _uow;

        public CarListingService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<CarListing> CarListings => _uow.CarListingRepository.GetAll();

        public CarListing Get(int id)
        {
            return _uow.CarListingRepository.GetById(id);
        }

        public bool VINExists(string vin, int excludeCarId)
        {
            return _uow.CarListingRepository.VINExists(vin, excludeCarId);
        }

        public void Add(CarListing car)
        {
            _uow.CarListingRepository.Add(car);
            _uow.SaveChanges();
        }

        public void Update(CarListing car)
        {
            _uow.CarListingRepository.Update(car);
            _uow.SaveChanges();
        }

        public void Delete(CarListing car)
        {
            _uow.CarListingRepository.Delete(car);
            _uow.SaveChanges();
        }

        public void Archive(int carId)
        {
            var carListing = _uow.CarListingRepository.GetById(carId);
            if (carListing != null)
            {
                carListing.Status = CarStatus.Archived;
                _uow.SaveChanges();
            }
        }

        public IEnumerable<CarListing> FilterCarListings(CarListingFilterVM filterCriteria)
        {
            IEnumerable<CarListing> filteredListings = _uow.CarListingRepository.GetAll();

            if (filterCriteria.SelectedBrandId != 0 && filterCriteria.SelectedBrandId != null)
            {
                filteredListings = filteredListings.Where(c => c.Model?.Brand?.BrandId == filterCriteria.SelectedBrandId);
            }

            if (filterCriteria.SelectedModelIds != null && filterCriteria.SelectedModelIds.Any())
            {
                filteredListings = filteredListings.Where(c => filterCriteria.SelectedModelIds.Contains(c.ModelId));
            }

            if (filterCriteria.SelectedEngineTypeIds != null && filterCriteria.SelectedEngineTypeIds.Any())
            {
                filteredListings = filteredListings.Where(c => filterCriteria.SelectedEngineTypeIds.Contains(c.EngineTypeId));
            }

            if (filterCriteria.SelectedTransmissionTypeIds != null && filterCriteria.SelectedTransmissionTypeIds.Any())
            {
                filteredListings = filteredListings.Where(c => filterCriteria.SelectedTransmissionTypeIds.Contains(c.TransmissionTypeId));
            }

            if (filterCriteria.SelectedBodyTypeIds != null && filterCriteria.SelectedBodyTypeIds.Any())
            {
                filteredListings = filteredListings.Where(c => filterCriteria.SelectedBodyTypeIds.Contains(c.BodyTypeId));
            }

            if (filterCriteria.SelectedFuelTypeIds != null && filterCriteria.SelectedFuelTypeIds.Any())
            {
                filteredListings = filteredListings.Where(c => filterCriteria.SelectedFuelTypeIds.Contains(c.FuelTypeId));
            }

            if (filterCriteria.YearFrom.HasValue)
            {
                filteredListings = filteredListings.Where(c => c.Year >= filterCriteria.YearFrom);
            }

            if (filterCriteria.YearTo.HasValue)
            {
                filteredListings = filteredListings.Where(c => c.Year <= filterCriteria.YearTo);
            }

            if (filterCriteria.Price.HasValue)
            {
                filteredListings = filteredListings.Where(c => c.Price <= filterCriteria.Price);
            }

            return filteredListings.ToList();
        }

        public IEnumerable<CarListing> GetPaginatedCarListings(int page, int pageSize)
        {
            return _uow.CarListingRepository.GetAll().Where(c => c.Status == CarStatus.Active).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public int GetTotalPages(int pageSize)
        {
            var totalCarListings = _uow.CarListingRepository.GetAll().Count(c => c.Status == CarStatus.Active);
            return (int)Math.Ceiling(totalCarListings / (double)pageSize);
        }

        public IEnumerable<CarListing> GetPaginatedCarListingsForFiltering(CarListingFilterVM filterCriteria, int page, int pageSize)
        {
            IEnumerable<CarListing> filteredListings = FilterCarListings(filterCriteria).Where(c => c.Status == CarStatus.Active);
            var paginatedListings = filteredListings.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return paginatedListings;
        }

        public int GetTotalPagesForFiltering(CarListingFilterVM filterCriteria, int pageSize)
        {
            IEnumerable<CarListing> filteredListings = FilterCarListings(filterCriteria).Where(c => c.Status == CarStatus.Active);
            var totalFilteredListingsCount = filteredListings.Count();
            var totalPages = (int)Math.Ceiling(totalFilteredListingsCount / (double)pageSize);
            return totalPages;
        }
    }
}
