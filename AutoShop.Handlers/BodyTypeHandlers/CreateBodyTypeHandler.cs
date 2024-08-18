using AutoShop.Commands.BodyTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BodyTypeHandlers
{
    public class CreateBodyTypeHandler : IRequestHandler<CreateBodyTypeCommand>
    {
        private readonly IBodyTypeService _bodyTypeService;

        public CreateBodyTypeHandler(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        public Task Handle(CreateBodyTypeCommand request, CancellationToken cancellationToken)
        {
            _bodyTypeService.Add(request.BodyType);
            return Task.CompletedTask;
        }
    }
}
