using AutoShop.Commands.TransmissionTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.TransmissionTypeHandlers
{
    public class CreateTransmissionTypeHandler : IRequestHandler<CreateTransmissionTypeCommand>
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public CreateTransmissionTypeHandler(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public Task Handle(CreateTransmissionTypeCommand request, CancellationToken cancellationToken)
        {
            _transmissionTypeService.Add(request.TransmissionType);
            return Task.CompletedTask;
        }
    }
}
