using AutoShop.Commands.TransmissionTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.TransmissionTypeHandlers
{
    public class UpdateTransmissionTypeHandler : IRequestHandler<UpdateTransmissionTypeCommand>
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public UpdateTransmissionTypeHandler(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public Task Handle(UpdateTransmissionTypeCommand request, CancellationToken cancellationToken)
        {
            _transmissionTypeService.Update(request.TransmissionType);
            return Task.CompletedTask;
        }
    }
}
