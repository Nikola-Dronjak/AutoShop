using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetPaginatedCarListingsForFilteringsHandler : IRequestHandler<GetPaginatedCarListingsForFilteringsQuery, IEnumerable<CarListing>>
    {
        private readonly ICarListingService _carListingService;

        public GetPaginatedCarListingsForFilteringsHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<IEnumerable<CarListing>> Handle(GetPaginatedCarListingsForFilteringsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarListing> paginatedCarListings = _carListingService.GetPaginatedCarListingsForFiltering(request.FilterCriteria, request.Page, request.PageSize);
            return Task.FromResult(paginatedCarListings);
        }
    }
}
