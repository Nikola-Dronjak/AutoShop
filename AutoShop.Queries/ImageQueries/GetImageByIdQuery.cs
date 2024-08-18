using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.ImageQueries
{
    public class GetImageByIdQuery : IRequest<Image>
    {
        public int Id { get; set; }

        public GetImageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
