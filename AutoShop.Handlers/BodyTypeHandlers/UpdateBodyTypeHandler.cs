using AutoShop.Commands.BodyTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BodyTypeHandlers
{
    public class UpdateBodyTypeHandler : IRequestHandler<UpdateBodyTypeCommand>
    {
        private readonly IBodyTypeService _bodyTypeService;

        public UpdateBodyTypeHandler(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        public Task Handle(UpdateBodyTypeCommand request, CancellationToken cancellationToken)
        {
            _bodyTypeService.Update(request.BodyType);
            return Task.CompletedTask;
        }
    }
}
