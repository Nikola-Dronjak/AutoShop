using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.BrandRepository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ApplicationDbContext _db;
        public BrandRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Brand> GetAll()
        {
            return _db.Brands.ToList();
        }

        public Brand GetById(int id)
        {
            return _db.Brands.FirstOrDefault(u => u.BrandId == id);
        }

        public void Add(Brand Brand)
        {
            _db.Brands.Add(Brand);
        }

        public void Update(Brand Brand)
        {
            _db.Brands.Update(Brand);
        }

        public void Delete(Brand Brand)
        {
            _db.Brands.Remove(Brand);
        }
    }
}
