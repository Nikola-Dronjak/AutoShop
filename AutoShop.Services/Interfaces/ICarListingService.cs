using AutoShop.Domain;
using AutoShop.ViewModel;

namespace AutoShop.Services.Interfaces
{
    public interface ICarListingService
    {
        public IEnumerable<CarListing> CarListings { get; }

        public CarListing Get(int id);

        public bool VINExists(string vin, int excludeCarId);

        public void Add(CarListing car);

        public void Update(CarListing car);

        public void Delete(CarListing car);

        public void Archive(int carId);

        IEnumerable<CarListing> FilterCarListings(CarListingFilterVM filterCriteria);

        IEnumerable<CarListing> GetPaginatedCarListings(int page, int pageSize);

        int GetTotalPages(int pageSize);

        IEnumerable<CarListing> GetPaginatedCarListingsForFiltering(CarListingFilterVM filterCriteria, int page, int pageSize);

        int GetTotalPagesForFiltering(CarListingFilterVM filterCriteria, int pageSize);
    }
}
