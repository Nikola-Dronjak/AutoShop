using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _uow;
        public ModelService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<Model> Models => _uow.ModelRepository.GetAll();


        public Model Get(int id)
        {
            return _uow.ModelRepository.GetById(id);
        }

        public void Add(Model Model)
        {
            _uow.ModelRepository.Add(Model);
            _uow.SaveChanges();
        }

        public void Update(Model Model)
        {
            _uow.ModelRepository.Update(Model);
            _uow.SaveChanges();
        }

        public void Delete(Model Model)
        {
            _uow.ModelRepository.Delete(Model);
            _uow.SaveChanges();
        }
    }
}
