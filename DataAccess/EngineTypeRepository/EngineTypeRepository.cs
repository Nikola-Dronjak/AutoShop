using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.EngineTypeRepository
{
    public class EngineTypeRepository : IEngineTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public EngineTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<EngineType> GetAll()
        {
            return _db.EngineTypes.ToList();
        }

        public EngineType GetById(int id)
        {
            return _db.EngineTypes.FirstOrDefault(u => u.EngineTypeId == id);
        }

        public void Add(EngineType engineType)
        {
            _db.EngineTypes.Add(engineType);
        }

        public void Update(EngineType engineType)
        {
            _db.EngineTypes.Update(engineType);
        }

        public void Delete(EngineType engineType)
        {
            _db.EngineTypes.Remove(engineType);
        }
    }
}
