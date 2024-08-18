using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BodyTypeCommands
{
    public class CreateBodyTypeCommand : IRequest
    {
        public BodyType BodyType { get; set; }

        public CreateBodyTypeCommand(BodyType bodyType)
        {
            BodyType = bodyType;
        }
    }
}
