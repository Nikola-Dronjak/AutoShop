using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetPaginatedCarListingsHandler : IRequestHandler<GetPaginatedCarListingsQuery, IEnumerable<CarListing>>
    {
        private readonly ICarListingService _carListingService;

        public GetPaginatedCarListingsHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<IEnumerable<CarListing>> Handle(GetPaginatedCarListingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarListing> paginatedCarListings = _carListingService.GetPaginatedCarListings(request.Page, request.PageSize);
            return Task.FromResult(paginatedCarListings);
        }
    }
}
