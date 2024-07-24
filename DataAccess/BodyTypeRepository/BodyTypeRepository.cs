using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.BodyTypeRepository
{
    public class BodyTypeRepository : IBodyTypeRepository
    {
        private readonly ApplicationDbContext _db;
        public BodyTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<BodyType> GetAll()
        {
            return _db.BodyTypes.ToList();
        }

        public BodyType GetById(int id)
        {
            return _db.BodyTypes.FirstOrDefault(u => u.BodyTypeId == id);
        }
        public void Add(BodyType BodyType)
        {
            _db.Add(BodyType);
        }

        public void Update(BodyType BodyType)
        {
            _db.Update(BodyType);
        }

        public void Delete(BodyType BodyType)
        {
            _db.Remove(BodyType);
        }
    }
}
