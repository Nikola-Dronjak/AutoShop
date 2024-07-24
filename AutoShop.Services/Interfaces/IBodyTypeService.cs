using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IBodyTypeService
    {
        public IEnumerable<BodyType> BodyTypes { get; }
        public BodyType Get(int id);
        public void Add(BodyType BodyType);
        public void Update(BodyType BodyType);
        public void Delete(BodyType BodyType);
    }
}
