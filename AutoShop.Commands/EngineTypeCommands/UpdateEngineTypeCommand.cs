using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.EngineTypeCommands
{
    public class UpdateEngineTypeCommand : IRequest
    {
        public EngineType EngineType { get; set; }

        public UpdateEngineTypeCommand(EngineType engineType)
        {
            EngineType = engineType;
        }
    }
}
