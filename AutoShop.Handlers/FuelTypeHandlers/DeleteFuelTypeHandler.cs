using AutoShop.Commands.FuelTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.FuelTypeHandlers
{
    public class DeleteFuelTypeHandler : IRequestHandler<DeleteFuelTypeCommand>
    {
        private readonly IFuelTypeService _fuelTypeService;

        public DeleteFuelTypeHandler(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public Task Handle(DeleteFuelTypeCommand request, CancellationToken cancellationToken)
        {
            _fuelTypeService.Delete(request.FuelType);
            return Task.CompletedTask;
        }
    }
}
