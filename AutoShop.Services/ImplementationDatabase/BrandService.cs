using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _uow;
        public BrandService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Brand> Brands => _uow.BrandRepository.GetAll();

        public Brand Get(int id)
        {
            return _uow.BrandRepository.GetById(id);
        }

        public void Add(Brand Brand)
        {
            _uow.BrandRepository.Add(Brand);
            _uow.SaveChanges();
        }
        public void Update(Brand Brand)
        {
            _uow.BrandRepository.Update(Brand);
            _uow.SaveChanges();
        }

        public void Delete(Brand Brand)
        {
            _uow.BrandRepository.Delete(Brand);
            _uow.SaveChanges();
        }
    }
}
