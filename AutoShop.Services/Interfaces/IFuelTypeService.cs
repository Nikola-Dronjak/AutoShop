using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IFuelTypeService
    {
        public IEnumerable<FuelType> FuelTypes { get; }

        public FuelType Get(int id);

        public void Add(FuelType fuelType);

        public void Update(FuelType fuelType);

        public void Delete(FuelType fuelType);
    }
}
