using AutoShop.Domain;
using AutoShop.Queries.ImageQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class GetAllImagesHandler : IRequestHandler<GetAllImagesQuery, IEnumerable<Image>>
    {
        private readonly IImageService _imageService;

        public GetAllImagesHandler(IImageService modelService)
        {
            _imageService = modelService;
        }

        public Task<IEnumerable<Image>> Handle(GetAllImagesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Image> images = _imageService.Images;
            return Task.FromResult(images);
        }
    }
}
