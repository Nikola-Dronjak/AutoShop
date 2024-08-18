using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.BodyTypeQueries
{
    public class GetBodyTypeByIdQuery : IRequest<BodyType>
    {
        public int Id { get; set; }

        public GetBodyTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
