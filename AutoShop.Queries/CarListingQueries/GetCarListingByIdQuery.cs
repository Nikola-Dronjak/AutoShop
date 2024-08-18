using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetCarListingByIdQuery : IRequest<CarListing>
    {
        public int Id { get; set; }

        public GetCarListingByIdQuery(int id)
        {
            Id = id;
        }
    }
}
