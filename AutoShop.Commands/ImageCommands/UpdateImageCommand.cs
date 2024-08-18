using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ImageCommands
{
    public class UpdateImageCommand : IRequest
    {
        public Image Image { get; set; }

        public UpdateImageCommand(Image image)
        {
            Image = image;
        }
    }
}
