using AutoShop.Commands.FuelTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.FuelTypeHandlers
{
    public class UpdateFuelTypeHandler : IRequestHandler<UpdateFuelTypeCommand>
    {
        private readonly IFuelTypeService _fuelTypeService;

        public UpdateFuelTypeHandler(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public Task Handle(UpdateFuelTypeCommand request, CancellationToken cancellationToken)
        {
            _fuelTypeService.Update(request.FuelType);
            return Task.CompletedTask;
        }
    }
}
