using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ImageCommands
{
    public class DeleteImageCommand : IRequest
    {
        public Image Image { get; set; }

        public DeleteImageCommand(Image image)
        {
            Image = image;
        }
    }
}
