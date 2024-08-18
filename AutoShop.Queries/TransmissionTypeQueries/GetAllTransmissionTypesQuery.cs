using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.TransmissionTypeQueries
{
    public class GetAllTransmissionTypesQuery : IRequest<IEnumerable<TransmissionType>>
    {
        public GetAllTransmissionTypesQuery()
        {

        }
    }
}
