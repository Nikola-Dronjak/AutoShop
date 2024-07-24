using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IBrandService
    {
        public IEnumerable<Brand> Brands { get; }
        public Brand Get(int id);
        public void Add(Brand Brand);
        public void Update(Brand Brand);
        public void Delete(Brand Brand);
    }
}
