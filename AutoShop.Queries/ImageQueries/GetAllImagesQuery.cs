using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.ImageQueries
{
    public class GetAllImagesQuery : IRequest<IEnumerable<Image>>
    {
        public GetAllImagesQuery()
        {

        }
    }
}
