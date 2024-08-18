using AutoShop.Commands.ModelCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ModelHandlers
{
    public class DeleteModelHandler : IRequestHandler<DeleteModelCommand>
    {
        private readonly IModelService _modelService;

        public DeleteModelHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public Task Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            _modelService.Delete(request.Model);
            return Task.CompletedTask;
        }
    }
}
