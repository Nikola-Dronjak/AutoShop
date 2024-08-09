using AutoShop.Domain;

namespace DataAccessLayer.ImageRepository
{
    public interface IImageRepository : IRepository<Image>
    {
        public IEnumerable<Image> GetAllImagesByCarId(int CarId);
    }
}
