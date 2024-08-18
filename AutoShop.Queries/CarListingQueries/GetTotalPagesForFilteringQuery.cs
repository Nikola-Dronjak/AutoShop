using AutoShop.ViewModel;
using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetTotalPagesForFilteringQuery : IRequest<int>
    {
        public CarListingFilterVM FilterCriteria { get; set; }
        public int PageSize { get; set; }

        public GetTotalPagesForFilteringQuery(CarListingFilterVM filterCriteria, int pageSize)
        {
            FilterCriteria = filterCriteria;
            PageSize = pageSize;
        }
    }
}
