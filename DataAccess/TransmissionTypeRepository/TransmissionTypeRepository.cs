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

        public void Add(TransmissionType TransmissionType)
        {
            _db.Add(TransmissionType);
        }

        public void Update(TransmissionType TransmissionType)
        {
            _db.Update(TransmissionType);
        }

        public void Delete(TransmissionType TransmissionType)
        {
            _db.Remove(TransmissionType);
        }
    }
}
