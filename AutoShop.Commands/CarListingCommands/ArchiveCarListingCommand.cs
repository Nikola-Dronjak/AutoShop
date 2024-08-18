using MediatR;

namespace AutoShop.Commands.CarListingCommands
{
    public class ArchiveCarListingCommand : IRequest
    {
        public int CarId { get; set; }

        public ArchiveCarListingCommand(int carId)
        {
            CarId = carId;
        }
    }
}
