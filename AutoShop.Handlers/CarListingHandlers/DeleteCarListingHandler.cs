using AutoShop.Commands.CarListingCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class DeleteCarListingHandler : IRequestHandler<DeleteCarListingCommand>
    {
        private readonly ICarListingService _carListingService;

        public DeleteCarListingHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task Handle(DeleteCarListingCommand request, CancellationToken cancellationToken)
        {
            _carListingService.Delete(request.CarListing);
            return Task.CompletedTask;
        }
    }
}
