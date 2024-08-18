using AutoShop.Domain;
using AutoShop.Queries.ImageQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class GetAllImagesByCarIdHandler : IRequestHandler<GetAllImagesByCarIdQuery, IEnumerable<Image>>
    {
        private readonly IImageService _imageService;

        public GetAllImagesByCarIdHandler(IImageService modelService)
        {
            _imageService = modelService;
        }

        public Task<IEnumerable<Image>> Handle(GetAllImagesByCarIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Image> imagesOfCar = _imageService.ImagesOfCar(request.CarId);
            return Task.FromResult(imagesOfCar);
        }
    }
}
