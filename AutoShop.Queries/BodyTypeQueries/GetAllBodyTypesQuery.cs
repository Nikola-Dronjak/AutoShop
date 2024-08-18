using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.BodyTypeQueries
{
    public class GetAllBodyTypesQuery : IRequest<IEnumerable<BodyType>>
    {
        public GetAllBodyTypesQuery()
        {

        }
    }
}
