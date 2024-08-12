using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IBrandService
    {
        public IEnumerable<Brand> Brands { get; }

        public Brand Get(int id);

        public void Add(Brand brand);

        public void Update(Brand brand);

        public void Delete(Brand brand);
    }
}
