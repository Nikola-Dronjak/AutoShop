using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.ModelRepository
{
    public class ModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext _db;
        public ModelRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Model> GetAll()
        {
            return _db.Models.ToList();
        }

        public Model GetById(int id)
        {
            return _db.Models.FirstOrDefault(u => u.ModelId == id);
        }

        public void Add(Model Model)
        {
            _db.Models.Add(Model);
        }

        public void Update(Model Model)
        {
            _db.Models.Update(Model);
        }

        public void Delete(Model Model)
        {
            _db.Models.Remove(Model);
        }
    }
}
