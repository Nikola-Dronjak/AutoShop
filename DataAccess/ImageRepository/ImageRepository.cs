using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.ImageRepository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext _db;

        public ImageRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Image> GetAll()
        {
            return _db.Images;
        }

        public IEnumerable<Image> GetAllImagesByCarId(int carId)
        {
            return _db.Images.Where(u => u.CarId == carId);
        }

        public Image GetById(int id)
        {
            return _db.Images.FirstOrDefault(u => u.ImageId == id);
        }

        public void Add(Image image)
        {
            _db.Add(image);
        }

        public void Update(Image image)
        {
            _db.Update(image);
        }

        public void Delete(Image image)
        {
            _db.Remove(image);
        }
    }
}
