using AutoShop.Domain;
using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetCarListingByIdHandler : IRequestHandler<GetCarListingByIdQuery, CarListing>
    {
        private readonly ICarListingService _carListingService;

        public GetCarListingByIdHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<CarListing> Handle(GetCarListingByIdQuery request, CancellationToken cancellationToken)
        {
            CarListing carListing = _carListingService.Get(request.Id);
            return Task.FromResult(carListing);
        }
    }
}
