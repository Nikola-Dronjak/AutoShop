using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.TransmissionTypeCommands
{
    public class CreateTransmissionTypeCommand : IRequest
    {
        public TransmissionType TransmissionType { get; set; }

        public CreateTransmissionTypeCommand(TransmissionType transmissionType)
        {
            TransmissionType = transmissionType;
        }
    }
}
