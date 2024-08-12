using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface ITransmissionTypeService
    {
        public IEnumerable<TransmissionType> TransmissionTypes { get; }

        public TransmissionType Get(int id);

        public void Add(TransmissionType transmissionType);

        public void Update(TransmissionType transmissionType);

        public void Delete(TransmissionType transmissionType);
    }
}
