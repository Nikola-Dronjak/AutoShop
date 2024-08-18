using AutoShop.Domain;
using AutoShop.Queries.ImageQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class GetImageByIdHandler : IRequestHandler<GetImageByIdQuery, Image>
    {
        private readonly IImageService _imageService;

        public GetImageByIdHandler(IImageService modelService)
        {
            _imageService = modelService;
        }

        public Task<Image> Handle(GetImageByIdQuery request, CancellationToken cancellationToken)
        {
            Image image = _imageService.Get(request.Id);
            return Task.FromResult(image);
        }
    }
}
