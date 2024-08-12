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

        public void Add(BodyType bodyType)
        {
            _db.Add(bodyType);
        }

        public void Update(BodyType bodyType)
        {
            _db.Update(bodyType);
        }

        public void Delete(BodyType bodyType)
        {
            _db.Remove(bodyType);
        }
    }
}
