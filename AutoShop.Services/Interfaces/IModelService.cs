using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IModelService
    {
        public IEnumerable<Model> Models { get; }

        public Model Get(int id);

        public void Add(Model model);

        public void Update(Model model);

        public void Delete(Model model);

    }
}
