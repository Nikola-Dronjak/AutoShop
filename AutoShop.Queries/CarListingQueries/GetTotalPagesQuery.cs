using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class GetTotalPagesQuery : IRequest<int>
    {
        public int PageSize { get; set; }

        public GetTotalPagesQuery(int pageSize)
        {
            PageSize = pageSize;
        }
    }
}
