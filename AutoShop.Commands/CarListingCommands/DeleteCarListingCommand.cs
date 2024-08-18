using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.CarListingCommands
{
    public class DeleteCarListingCommand : IRequest
    {
        public CarListing CarListing { get; set; }

        public DeleteCarListingCommand(CarListing carListing)
        {
            CarListing = carListing;
        }
    }
}
