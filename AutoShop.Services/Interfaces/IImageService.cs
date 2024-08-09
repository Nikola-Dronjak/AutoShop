using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IImageService
    {
        public IEnumerable<Image> Images { get; }
        public IEnumerable<Image> ImagesOfCar(int CarId);
        public Image Get(int id);
        public void Add(Image Image);
        public void Update(Image Image);
        public void Delete(Image Image);
    }
}
