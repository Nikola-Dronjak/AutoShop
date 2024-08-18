using AutoShop.Commands.BodyTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BodyTypeHandlers
{
    public class DeleteBodyTypeHandler : IRequestHandler<DeleteBodyTypeCommand>
    {
        private readonly IBodyTypeService _bodyTypeService;

        public DeleteBodyTypeHandler(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        public Task Handle(DeleteBodyTypeCommand request, CancellationToken cancellationToken)
        {
            _bodyTypeService.Delete(request.BodyType);
            return Task.CompletedTask;
        }
    }
}
