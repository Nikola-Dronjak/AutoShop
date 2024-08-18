using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ImageCommands
{
    public class CreateImageCommand : IRequest
    {
        public Image Image { get; set; }

        public CreateImageCommand(Image image)
        {
            Image = image;
        }
    }
}
