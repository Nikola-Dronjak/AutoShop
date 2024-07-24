
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

        public void Add(EngineType EngineType)
        {
            _db.EngineTypes.Add(EngineType);
        }

        public void Update(EngineType EngineType)
        {
            _db.EngineTypes.Update(EngineType);
        }

        public void Delete(EngineType EngineType)
        {
            _db.EngineTypes.Remove(EngineType);
        }
    }
}
