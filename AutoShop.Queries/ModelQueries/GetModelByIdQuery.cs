using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.ModelQueries
{
    public class GetModelByIdQuery : IRequest<Model>
    {
        public int Id { get; set; }

        public GetModelByIdQuery(int id)
        {
            Id = id;
        }
    }
}
