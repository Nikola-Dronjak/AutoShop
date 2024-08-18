using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.FuelTypeCommands
{
    public class UpdateFuelTypeCommand : IRequest
    {
        public FuelType FuelType { get; set; }

        public UpdateFuelTypeCommand(FuelType fuelType)
        {
            FuelType = fuelType;
        }
    }
}
