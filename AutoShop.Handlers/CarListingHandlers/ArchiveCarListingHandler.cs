using AutoShop.Commands.CarListingCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class ArchiveCarListingHandler : IRequestHandler<ArchiveCarListingCommand>
    {
        private readonly ICarListingService _carListingService;

        public ArchiveCarListingHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task Handle(ArchiveCarListingCommand request, CancellationToken cancellationToken)
        {
            _carListingService.Archive(request.CarId);
            return Task.CompletedTask;
        }
    }
}
