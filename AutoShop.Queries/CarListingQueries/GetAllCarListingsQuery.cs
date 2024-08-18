using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetAllCarListingsQuery : IRequest<IEnumerable<CarListing>>
    {
        public GetAllCarListingsQuery()
        {

        }
    }
}
