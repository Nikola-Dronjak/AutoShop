using AutoShop.Domain;
using AutoShop.Infrastructure;

namespace DataAccessLayer.TransmissionTypeRepository
{
    public class TransmissionTypeRepository : ITransmissionTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public TransmissionTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<TransmissionType> GetAll()
        {
            return _db.TransmissionTypes.ToList();
        }

        public TransmissionType GetById(int id)
        {
            return _db.TransmissionTypes.FirstOrDefault(u => u.TransmissionTypeId == id);
        }

        public void Add(TransmissionType transmissionType)
        {
            _db.Add(transmissionType);
        }

        public void Update(TransmissionType transmissionType)
        {
            _db.Update(transmissionType);
        }

        public void Delete(TransmissionType transmissionType)
        {
            _db.Remove(transmissionType);
        }
    }
}
