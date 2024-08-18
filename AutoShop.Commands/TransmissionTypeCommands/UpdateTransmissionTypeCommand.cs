using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.TransmissionTypeCommands
{
    public class UpdateTransmissionTypeCommand : IRequest
    {
        public TransmissionType TransmissionType { get; set; }

        public UpdateTransmissionTypeCommand(TransmissionType transmissionType)
        {
            TransmissionType = transmissionType;
        }
    }
}
