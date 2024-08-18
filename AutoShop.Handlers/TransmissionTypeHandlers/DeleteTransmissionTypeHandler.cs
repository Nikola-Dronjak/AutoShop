using AutoShop.Commands.TransmissionTypeCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.TransmissionTypeHandlers
{
    public class DeleteTransmissionTypeHandler : IRequestHandler<DeleteTransmissionTypeCommand>
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public DeleteTransmissionTypeHandler(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public Task Handle(DeleteTransmissionTypeCommand request, CancellationToken cancellationToken)
        {
            _transmissionTypeService.Delete(request.TransmissionType);
            return Task.CompletedTask;
        }
    }
}
