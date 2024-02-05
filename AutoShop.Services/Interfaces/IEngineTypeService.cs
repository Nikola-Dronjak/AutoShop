using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IEngineTypeService
    {
        public IEnumerable<EngineType> EngineTypes { get; }
        public EngineType Get(int id);
        public void Add(EngineType EngineType);
        public void Update(EngineType EngineType);
        public void Delete(EngineType EngineType);
    }
}
