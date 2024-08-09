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

        public IEnumerable<Image> GetAllImagesByCarId(int CarId)
        {
            return _db.Images.Where(u => u.CarId == CarId);
        }

        public Image GetById(int id)
        {
            return _db.Images.FirstOrDefault(u => u.ImageId == id);
        }

        public void Add(Image Image)
        {
            _db.Add(Image);
        }

        public void Update(Image Image)
        {
            _db.Update(Image);
        }

        public void Delete(Image Image)
        {
            _db.Remove(Image);
        }
    }
}
