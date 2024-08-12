using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IImageService
    {
        public IEnumerable<Image> Images { get; }

        public IEnumerable<Image> ImagesOfCar(int carId);

        public Image Get(int id);

        public void Add(Image image);

        public void Update(Image image);

        public void Delete(Image image);
    }
}
