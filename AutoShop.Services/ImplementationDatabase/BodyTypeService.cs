using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly IUnitOfWork _uow;

        public BodyTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<BodyType> BodyTypes => _uow.BodyTypeRepository.GetAll();

        public BodyType Get(int id)
        {
            return _uow.BodyTypeRepository.GetById(id);
        }

        public void Add(BodyType bodyType)
        {
            _uow.BodyTypeRepository.Add(bodyType);
            _uow.SaveChanges();
        }

        public void Update(BodyType bodyType)
        {
            _uow.BodyTypeRepository.Update(bodyType);
            _uow.SaveChanges();
        }

        public void Delete(BodyType bodyType)
        {
            _uow.BodyTypeRepository.Delete(bodyType);
            _uow.SaveChanges();
        }
    }
}
