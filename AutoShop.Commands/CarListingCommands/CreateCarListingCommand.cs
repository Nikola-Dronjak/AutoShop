using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.CarListingCommands
{
    public class CreateCarListingCommand : IRequest
    {
        public CarListing CarListing { get; set; }

        public CreateCarListingCommand(CarListing carListing)
        {
            CarListing = carListing;
        }
    }
}
