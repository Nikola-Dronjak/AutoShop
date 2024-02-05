using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IModelService
    {
        public IEnumerable<Model> Models { get; }
        public Model Get(int id);
        public void Add(Model Model);
        public void Update(Model Model);
        public void Delete(Model Model);
    }
}
