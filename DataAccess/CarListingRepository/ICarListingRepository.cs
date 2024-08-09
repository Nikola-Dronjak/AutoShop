using AutoShop.Domain;

namespace DataAccessLayer.CarListingRepository
{
    public interface ICarListingRepository : IRepository<CarListing>
    {
        public bool VINExists(string vin, int excludeCarId);
    }
}
