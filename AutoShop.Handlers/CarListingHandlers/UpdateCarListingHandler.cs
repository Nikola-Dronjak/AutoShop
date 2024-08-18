using AutoShop.Commands.CarListingCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class UpdateCarListingHandler : IRequestHandler<UpdateCarListingCommand>
    {
        private readonly ICarListingService _carListingService;

        public UpdateCarListingHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task Handle(UpdateCarListingCommand request, CancellationToken cancellationToken)
        {
            _carListingService.Update(request.CarListing);
            return Task.CompletedTask;
        }
    }
}
