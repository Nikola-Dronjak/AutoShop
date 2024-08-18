using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.BrandQueries
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>>
    {
        public GetAllBrandsQuery()
        {

        }
    }
}
