using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.FuelTypeRepository
{
    public class FuelTypeRepository : IFuelTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public FuelTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<FuelType> GetAll()
        {
            return _db.FuelTypes.ToList();
        }

        public FuelType GetById(int id)
        {
            return _db.FuelTypes.FirstOrDefault(u => u.FuelTypeId == id);
        }

        public void Add(FuelType fuelType)
        {
            _db.Add(fuelType);
        }

        public void Update(FuelType fuelType)
        {
            _db.Update(fuelType);
        }

        public void Delete(FuelType fuelType)
        {
            _db.Remove(fuelType);
        }
    }
}
