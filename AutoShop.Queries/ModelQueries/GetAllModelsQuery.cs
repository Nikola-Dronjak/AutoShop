using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.ModelQueries
{
    public class GetAllModelsQuery : IRequest<IEnumerable<Model>>
    {
        public GetAllModelsQuery()
        {

        }
    }
}
