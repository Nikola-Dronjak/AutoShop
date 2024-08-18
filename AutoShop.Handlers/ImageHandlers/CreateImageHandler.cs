using AutoShop.Commands.ImageCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class CreateImageHandler : IRequestHandler<CreateImageCommand>
    {
        private readonly IImageService _imageService;

        public CreateImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public Task Handle(CreateImageCommand request, CancellationToken cancellationToken)
        {
            _imageService.Add(request.Image);
            return Task.CompletedTask;
        }
    }
}
