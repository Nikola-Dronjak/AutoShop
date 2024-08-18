using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetAllCarListingsHandler : IRequestHandler<GetAllCarListingsQuery, IEnumerable<CarListing>>
    {
        private readonly ICarListingService _carListingService;

        public GetAllCarListingsHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<IEnumerable<CarListing>> Handle(GetAllCarListingsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<CarListing> carListings = _carListingService.CarListings;
            return Task.FromResult(carListings);
        }
    }
}
