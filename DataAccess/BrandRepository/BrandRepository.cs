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

        public void Add(Brand brand)
        {
            _db.Brands.Add(brand);
        }

        public void Update(Brand brand)
        {
            _db.Brands.Update(brand);
        }

        public void Delete(Brand brand)
        {
            _db.Brands.Remove(brand);
        }
    }
}
