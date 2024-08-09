using DataAccessLayer.BodyTypeRepository;
using DataAccessLayer.BrandRepository;
using DataAccessLayer.CarListingRepository;
using DataAccessLayer.EngineTypeRepository;
using DataAccessLayer.FuelTypeRepository;
using DataAccessLayer.ImageRepository;
using DataAccessLayer.ModelRepository;
using DataAccessLayer.TransmissionTypeRepository;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IBodyTypeRepository BodyTypeRepository { get; set; }
        public IFuelTypeRepository FuelTypeRepository { get; set; }
        public ITransmissionTypeRepository TransmissionTypeRepository { get; set; }
        public IEngineTypeRepository EngineTypeRepository { get; set; }
        public IModelRepository ModelRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IImageRepository ImageRepository { get; set; }
        public ICarListingRepository CarListingRepository { get; set; }

        public void SaveChanges();
    }
}
