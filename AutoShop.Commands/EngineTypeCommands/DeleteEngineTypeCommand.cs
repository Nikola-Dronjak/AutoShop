using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.EngineTypeCommands
{
    public class DeleteEngineTypeCommand : IRequest
    {
        public EngineType EngineType { get; set; }

        public DeleteEngineTypeCommand(EngineType engineType)
        {
            EngineType = engineType;
        }
    }
}
