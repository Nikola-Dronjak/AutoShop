using AutoShop.Domain;
using AutoShop.ViewModel;

namespace AutoShop.Services.Interfaces
{
    public interface ICarListingService
    {
        public IEnumerable<CarListing> CarListings { get; }
        public CarListing Get(int id);
        public void Add(CarListing Car);
        public void Update(CarListing Car);
        public void Delete(CarListing Car);
        public void Archive(int CarId);
        IEnumerable<CarListing> FilterCarListings(CarListingFilterVM filterCriteria);
        IEnumerable<CarListing> GetPaginatedCarListings(int page, int pageSize);
        int GetTotalPages(int pageSize);
        IEnumerable<CarListing> GetPaginatedCarListingsForFiltering(CarListingFilterVM filterCriteria, int page, int pageSize);
        int GetTotalPagesForFiltering(CarListingFilterVM filterCriteria, int pageSize);
    }
}
