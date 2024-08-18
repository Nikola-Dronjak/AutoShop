using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.CarListingCommands
{
    public class UpdateCarListingCommand : IRequest
    {
        public CarListing CarListing { get; set; }

        public UpdateCarListingCommand(CarListing carListing)
        {
            CarListing = carListing;
        }
    }
}
