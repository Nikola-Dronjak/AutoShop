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

        public void Add(Model model)
        {
            _uow.ModelRepository.Add(model);
            _uow.SaveChanges();
        }

        public void Update(Model model)
        {
            _uow.ModelRepository.Update(model);
            _uow.SaveChanges();
        }

        public void Delete(Model model)
        {
            _uow.ModelRepository.Delete(model);
            _uow.SaveChanges();
        }
    }
}
