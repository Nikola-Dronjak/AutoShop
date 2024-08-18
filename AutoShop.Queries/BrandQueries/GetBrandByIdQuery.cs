using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.BrandQueries
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public int Id { get; set; }

        public GetBrandByIdQuery(int id)
        {
            Id = id;
        }
    }
}
