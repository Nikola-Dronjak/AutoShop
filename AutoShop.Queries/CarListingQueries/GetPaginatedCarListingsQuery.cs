using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetPaginatedCarListingsQuery : IRequest<IEnumerable<CarListing>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedCarListingsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
