using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BodyTypeCommands
{
    public class UpdateBodyTypeCommand : IRequest
    {
        public BodyType BodyType { get; set; }

        public UpdateBodyTypeCommand(BodyType bodyType)
        {
            BodyType = bodyType;
        }
    }
}
