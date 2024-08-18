using AutoShop.Domain;
using AutoShop.ViewModel;
using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetPaginatedCarListingsForFilteringsQuery : IRequest<IEnumerable<CarListing>>
    {
        public CarListingFilterVM FilterCriteria { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedCarListingsForFilteringsQuery(CarListingFilterVM filterCriteria, int page, int pageSize)
        {
            FilterCriteria = filterCriteria;
            Page = page;
            PageSize = pageSize;
        }
    }
}
