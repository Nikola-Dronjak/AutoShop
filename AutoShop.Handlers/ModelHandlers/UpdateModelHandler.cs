using AutoShop.Commands.ModelCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ModelHandlers
{
    public class UpdateModelHandler : IRequestHandler<UpdateModelCommand>
    {
        private readonly IModelService _modelService;

        public UpdateModelHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public Task Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            _modelService.Update(request.Model);
            return Task.CompletedTask;
        }
    }
}
