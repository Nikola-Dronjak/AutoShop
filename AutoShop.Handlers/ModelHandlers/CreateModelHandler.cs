using AutoShop.Commands.ModelCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ModelHandlers
{
    public class CreateModelHandler : IRequestHandler<CreateModelCommand>
    {
        private readonly IModelService _modelService;

        public CreateModelHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public Task Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            _modelService.Add(request.Model);
            return Task.CompletedTask;
        }
    }
}
