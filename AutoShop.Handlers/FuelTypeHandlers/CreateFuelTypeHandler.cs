using AutoShop.Commands.FuelTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.FuelTypeHandlers
{
    public class CreateFuelTypeHandler : IRequestHandler<CreateFuelTypeCommand>
    {
        private readonly IFuelTypeService _fuelTypeService;

        public CreateFuelTypeHandler(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public Task Handle(CreateFuelTypeCommand request, CancellationToken cancellationToken)
        {
            _fuelTypeService.Add(request.FuelType);
            return Task.CompletedTask;
        }
    }
}
