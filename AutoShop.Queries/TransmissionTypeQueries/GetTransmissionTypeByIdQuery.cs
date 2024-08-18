using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.TransmissionTypeQueries
{
    public class GetTransmissionTypeByIdQuery : IRequest<TransmissionType>
    {
        public int Id { get; set; }

        public GetTransmissionTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
