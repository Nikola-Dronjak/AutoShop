using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BodyTypeCommands
{
    public class DeleteBodyTypeCommand : IRequest
    {
        public BodyType BodyType { get; set; }

        public DeleteBodyTypeCommand(BodyType bodyType)
        {
            BodyType = bodyType;
        }
    }
}
