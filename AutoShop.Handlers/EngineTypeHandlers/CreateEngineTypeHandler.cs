using AutoShop.Commands.EngineTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.EngineTypeHandlers
{
    public class CreateEngineTypeHandler : IRequestHandler<CreateEngineTypeCommand>
    {
        private readonly IEngineTypeService _engineTypeService;

        public CreateEngineTypeHandler(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        public Task Handle(CreateEngineTypeCommand request, CancellationToken cancellationToken)
        {
            _engineTypeService.Add(request.EngineType);
            return Task.CompletedTask;
        }
    }
}
