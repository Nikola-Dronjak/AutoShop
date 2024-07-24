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

        public void Add(TransmissionType TransmissionType)
        {
            _uow.TransmissionTypeRepository.Add(TransmissionType);
            _uow.SaveChanges();
        }

        public void Update(TransmissionType TransmissionType)
        {
            _uow.TransmissionTypeRepository.Update(TransmissionType);
            _uow.SaveChanges();
        }

        public void Delete(TransmissionType TransmissionType)
        {
            _uow.TransmissionTypeRepository.Delete(TransmissionType);
            _uow.SaveChanges();
        }
    }
}
