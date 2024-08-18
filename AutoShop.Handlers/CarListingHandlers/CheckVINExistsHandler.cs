using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class CheckVINExistsHandler : IRequestHandler<CheckVINExistsQuery, bool>
    {
        private readonly ICarListingService _carListingService;

        public CheckVINExistsHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<bool> Handle(CheckVINExistsQuery request, CancellationToken cancellationToken)
        {
            bool vinExists = _carListingService.VINExists(request.VIN, request.ExcludedCarId);
            return Task.FromResult(vinExists);
        }
    }
}
