using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.EngineTypeQueries
{
    public class GetAllEngineTypesQuery : IRequest<IEnumerable<EngineType>>
    {
        public GetAllEngineTypesQuery()
        {

        }
    }
}
