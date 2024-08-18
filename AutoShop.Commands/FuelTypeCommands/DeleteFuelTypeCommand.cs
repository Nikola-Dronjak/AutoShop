using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.FuelTypeCommands
{
    public class DeleteFuelTypeCommand : IRequest
    {
        public FuelType FuelType { get; set; }

        public DeleteFuelTypeCommand(FuelType fuelType)
        {
            FuelType = fuelType;
        }
    }
}
