using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.ImageQueries
{
    public class GetAllImagesByCarIdQuery : IRequest<IEnumerable<Image>>
    {
        public int CarId { get; set; }

        public GetAllImagesByCarIdQuery(int carId)
        {
            CarId = carId;
        }
    }
}
