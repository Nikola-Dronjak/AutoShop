using AutoShop.Commands.EngineTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.EngineTypeHandlers
{
    public class DeleteEngineTypeHandler : IRequestHandler<DeleteEngineTypeCommand>
    {
        private readonly IEngineTypeService _engineTypeService;

        public DeleteEngineTypeHandler(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        public Task Handle(DeleteEngineTypeCommand request, CancellationToken cancellationToken)
        {
            _engineTypeService.Delete(request.EngineType);
            return Task.CompletedTask;
        }
    }
}
