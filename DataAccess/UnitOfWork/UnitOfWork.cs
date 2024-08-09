using AutoShop.Infrastructure;
using DataAccessLayer.BodyTypeRepository;
using DataAccessLayer.BrandRepository;
using DataAccessLayer.ModelRepository;
using DataAccessLayer.CarListingRepository;
using DataAccessLayer.EngineTypeRepository;
using DataAccessLayer.FuelTypeRepository;
using DataAccessLayer.TransmissionTypeRepository;
using DataAccessLayer.ImageRepository;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            BodyTypeRepository = new BodyTypeRepository.BodyTypeRepository(context);
            FuelTypeRepository = new FuelTypeRepository.FuelTypeRepository(context);
            TransmissionTypeRepository = new TransmissionTypeRepository.TransmissionTypeRepository(context);
            EngineTypeRepository = new EngineTypeRepository.EngineTypeRepository(context);
            ModelRepository = new ModelRepository.ModelRepository(context);
            BrandRepository = new BrandRepository.BrandRepository(context);
            ImageRepository = new ImageRepository.ImageRepository(context);
            CarListingRepository = new CarListingRepository.CarListingRepository(context);
        }
        public IBodyTypeRepository BodyTypeRepository { get; set; }
        public IFuelTypeRepository FuelTypeRepository { get; set; }
        public ITransmissionTypeRepository TransmissionTypeRepository { get; set; }
        public IEngineTypeRepository EngineTypeRepository { get; set; }
        public IModelRepository ModelRepository { get; set; }
        public IBrandRepository BrandRepository { get; set; }
        public IImageRepository ImageRepository { get; set; }
        public ICarListingRepository CarListingRepository { get; set; }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
