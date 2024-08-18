using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.EngineTypeCommands
{
    public class CreateEngineTypeCommand : IRequest
    {
        public EngineType EngineType { get; set; }

        public CreateEngineTypeCommand(EngineType engineType)
        {
            EngineType = engineType;
        }
    }
}
