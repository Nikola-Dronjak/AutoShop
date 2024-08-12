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

        public IEnumerable<Image> ImagesOfCar(int carId)
        {
            return _uow.ImageRepository.GetAllImagesByCarId(carId);
        }

        public Image Get(int id)
        {
            return _uow.ImageRepository.GetById(id);
        }

        public void Add(Image image)
        {
            _uow.ImageRepository.Add(image);
            _uow.SaveChanges();
        }
        public void Update(Image image)
        {
            _uow.ImageRepository.Update(image);
            _uow.SaveChanges();
        }

        public void Delete(Image image)
        {
            _uow.ImageRepository.Delete(image);
            _uow.SaveChanges();
        }
    }
}
