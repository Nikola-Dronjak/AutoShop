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

        public void Add(Model model)
        {
            _db.Models.Add(model);
        }

        public void Update(Model model)
        {
            _db.Models.Update(model);
        }

        public void Delete(Model model)
        {
            _db.Models.Remove(model);
        }
    }
}
