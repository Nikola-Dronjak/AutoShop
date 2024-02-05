using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IFuelTypeService
    {
        public IEnumerable<FuelType> FuelTypes { get; }
        public FuelType Get(int id);
        public void Add(FuelType FuelType);
        public void Update(FuelType FuelType);
        public void Delete(FuelType FuelType);
    }
}
