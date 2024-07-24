using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IUnitOfWork _uow;
        public FuelTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<FuelType> FuelTypes => _uow.FuelTypeRepository.GetAll();
        public FuelType Get(int id)
        {
            return _uow.FuelTypeRepository.GetById(id);
        }

        public void Add(FuelType FuelType)
        {
            _uow.FuelTypeRepository.Add(FuelType);
            _uow.SaveChanges();
        }
        public void Update(FuelType FuelType)
        {
            _uow.FuelTypeRepository.Update(FuelType);
            _uow.SaveChanges();
        }

        public void Delete(FuelType FuelType)
        {
            _uow.FuelTypeRepository.Delete(FuelType);
            _uow.SaveChanges();
        }
    }
}
