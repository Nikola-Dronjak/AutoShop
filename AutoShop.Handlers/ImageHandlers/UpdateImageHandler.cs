using AutoShop.Commands.ImageCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class UpdateImageHandler : IRequestHandler<UpdateImageCommand>
    {
        private readonly IImageService _imageService;

        public UpdateImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public Task Handle(UpdateImageCommand request, CancellationToken cancellationToken)
        {
            _imageService.Update(request.Image);
            return Task.CompletedTask;
        }
    }
}
