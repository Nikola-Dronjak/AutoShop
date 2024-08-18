using AutoShop.Commands.CarListingCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class CreateCarListingHandler : IRequestHandler<CreateCarListingCommand>
    {
        private readonly ICarListingService _carListingService;

        public CreateCarListingHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task Handle(CreateCarListingCommand request, CancellationToken cancellationToken)
        {
            _carListingService.Add(request.CarListing);
            return Task.CompletedTask;
        }
    }
}
