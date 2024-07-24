using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class EngineTypeServices : IEngineTypeService
    {
        private readonly IUnitOfWork _uow;
        public EngineTypeServices(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<EngineType> EngineTypes => _uow.EngineTypeRepository.GetAll();
        
        public EngineType Get(int id)
        {
            return _uow.EngineTypeRepository.GetById(id);
        }

        public void Add(EngineType EngineType)
        {
            _uow.EngineTypeRepository.Add(EngineType);
            _uow.SaveChanges();
        }

        public void Update(EngineType EngineType)
        {
            _uow.EngineTypeRepository.Update(EngineType);
            _uow.SaveChanges();
        }

        public void Delete(EngineType EngineType)
        {
            _uow.EngineTypeRepository.Delete(EngineType);
            _uow.SaveChanges();
        }
    }
}
