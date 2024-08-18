using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.TransmissionTypeCommands
{
    public class DeleteTransmissionTypeCommand : IRequest
    {
        public TransmissionType TransmissionType { get; set; }

        public DeleteTransmissionTypeCommand(TransmissionType transmissionType)
        {
            TransmissionType = transmissionType;
        }
    }
}
