using AutoShop.Domain;
using AutoShop.Queries.TransmissionTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.TransmissionTypeHandlers
{
    public class GetTransmissionTypeByIdHandler : IRequestHandler<GetTransmissionTypeByIdQuery, TransmissionType>
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public GetTransmissionTypeByIdHandler(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public Task<TransmissionType> Handle(GetTransmissionTypeByIdQuery request, CancellationToken cancellationToken)
        {
            TransmissionType transmissionType = _transmissionTypeService.Get(request.Id);
            return Task.FromResult(transmissionType);
        }
    }
}
