using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.EngineTypeQueries
{
    public class GetEngineTypeByIdQuery : IRequest<EngineType>
    {
        public int Id { get; set; }

        public GetEngineTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
