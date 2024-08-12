using AutoShop.Domain;
using AutoShop.Services.Interfaces;
using DataAccessLayer.UnitOfWork;

namespace AutoShop.Services.ImplementationDatabase
{
    public class TransmissionTypeService : ITransmissionTypeService
    {
        private readonly IUnitOfWork _uow;

        public TransmissionTypeService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IEnumerable<TransmissionType> TransmissionTypes => _uow.TransmissionTypeRepository.GetAll();

        public TransmissionType Get(int id)
        {
            return _uow.TransmissionTypeRepository.GetById(id);
        }

        public void Add(TransmissionType transmissionType)
        {
            _uow.TransmissionTypeRepository.Add(transmissionType);
            _uow.SaveChanges();
        }

        public void Update(TransmissionType transmissionType)
        {
            _uow.TransmissionTypeRepository.Update(transmissionType);
            _uow.SaveChanges();
        }

        public void Delete(TransmissionType transmissionType)
        {
            _uow.TransmissionTypeRepository.Delete(transmissionType);
            _uow.SaveChanges();
        }
    }
}
