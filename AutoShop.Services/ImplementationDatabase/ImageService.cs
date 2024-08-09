using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class ImageService : IImageService
    {
        private readonly IUnitOfWork _uow;
        public ImageService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IEnumerable<Image> Images => _uow.ImageRepository.GetAll();
        public IEnumerable<Image> ImagesOfCar(int CarId)
        {
            return _uow.ImageRepository.GetAllImagesByCarId(CarId);
        }

        public Image Get(int id)
        {
            return _uow.ImageRepository.GetById(id);
        }

        public void Add(Image Image)
        {
            _uow.ImageRepository.Add(Image);
            _uow.SaveChanges();
        }
        public void Update(Image Image)
        {
            _uow.ImageRepository.Update(Image);
            _uow.SaveChanges();
        }

        public void Delete(Image Image)
        {
            _uow.ImageRepository.Delete(Image);
            _uow.SaveChanges();
        }
    }
}
