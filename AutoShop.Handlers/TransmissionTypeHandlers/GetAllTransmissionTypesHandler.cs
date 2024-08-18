using AutoShop.Domain;
using AutoShop.Queries.TransmissionTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.TransmissionTypeHandlers
{
    public class GetAllTransmissionTypesHandler : IRequestHandler<GetAllTransmissionTypesQuery, IEnumerable<TransmissionType>>
    {
        private readonly ITransmissionTypeService _transmissionTypeService;

        public GetAllTransmissionTypesHandler(ITransmissionTypeService transmissionTypeService)
        {
            _transmissionTypeService = transmissionTypeService;
        }

        public Task<IEnumerable<TransmissionType>> Handle(GetAllTransmissionTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<TransmissionType> transmissionTypes = _transmissionTypeService.TransmissionTypes;
            return Task.FromResult(transmissionTypes);
        }
    }
}
