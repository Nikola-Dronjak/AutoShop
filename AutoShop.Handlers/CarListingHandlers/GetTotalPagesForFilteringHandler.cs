using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetTotalPagesForFilteringHandler : IRequestHandler<GetTotalPagesForFilteringQuery, int>
    {
        private readonly ICarListingService _carListingService;

        public GetTotalPagesForFilteringHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<int> Handle(GetTotalPagesForFilteringQuery request, CancellationToken cancellationToken)
        {
            int totalPages = _carListingService.GetTotalPagesForFiltering(request.FilterCriteria, request.PageSize);
            return Task.FromResult(totalPages);
        }
    }
}
