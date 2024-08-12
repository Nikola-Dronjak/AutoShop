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

        public void Add(EngineType engineType)
        {
            _uow.EngineTypeRepository.Add(engineType);
            _uow.SaveChanges();
        }

        public void Update(EngineType engineType)
        {
            _uow.EngineTypeRepository.Update(engineType);
            _uow.SaveChanges();
        }

        public void Delete(EngineType engineType)
        {
            _uow.EngineTypeRepository.Delete(engineType);
            _uow.SaveChanges();
        }
    }
}
