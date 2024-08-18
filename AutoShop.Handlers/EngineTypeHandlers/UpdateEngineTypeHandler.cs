using AutoShop.Commands.EngineTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.EngineTypeHandlers
{
    public class UpdateEngineTypeHandler : IRequestHandler<UpdateEngineTypeCommand>
    {
        private readonly IEngineTypeService _engineTypeService;

        public UpdateEngineTypeHandler(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        public Task Handle(UpdateEngineTypeCommand request, CancellationToken cancellationToken)
        {
            _engineTypeService.Update(request.EngineType);
            return Task.CompletedTask;
        }
    }
}
