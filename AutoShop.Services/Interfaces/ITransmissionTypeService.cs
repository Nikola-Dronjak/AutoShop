using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface ITransmissionTypeService
    {
        public IEnumerable<TransmissionType> TransmissionTypes { get; }
        public TransmissionType Get(int id);
        public void Add(TransmissionType TransmissionType);
        public void Update(TransmissionType TransmissionType);
        public void Delete(TransmissionType TransmissionType);
    }
}
