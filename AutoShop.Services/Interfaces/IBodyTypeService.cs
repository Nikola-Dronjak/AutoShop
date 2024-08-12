using AutoShop.Domain;

namespace AutoShop.Services.Interfaces
{
    public interface IBodyTypeService
    {
        public IEnumerable<BodyType> BodyTypes { get; }

        public BodyType Get(int id);

        public void Add(BodyType bodyType);

        public void Update(BodyType bodyType);

        public void Delete(BodyType bodyType);
    }
}
