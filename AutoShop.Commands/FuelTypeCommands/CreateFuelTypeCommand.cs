using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.FuelTypeCommands
{
    public class CreateFuelTypeCommand : IRequest
    {
        public FuelType FuelType { get; set; }

        public CreateFuelTypeCommand(FuelType fuelType)
        {
            FuelType = fuelType;
        }
    }
}
