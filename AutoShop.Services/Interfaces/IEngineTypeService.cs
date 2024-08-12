using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IEngineTypeService
    {
        public IEnumerable<EngineType> EngineTypes { get; }

        public EngineType Get(int id);

        public void Add(EngineType engineType);

        public void Update(EngineType engineType);

        public void Delete(EngineType engineType);
    }
}
