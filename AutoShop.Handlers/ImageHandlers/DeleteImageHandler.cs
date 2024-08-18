using AutoShop.Commands.ImageCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ImageHandlers
{
    public class DeleteImageHandler : IRequestHandler<DeleteImageCommand>
    {
        private readonly IImageService _imageService;

        public DeleteImageHandler(IImageService imageService)
        {
            _imageService = imageService;
        }

        public Task Handle(DeleteImageCommand request, CancellationToken cancellationToken)
        {
            _imageService.Delete(request.Image);
            return Task.CompletedTask;
        }
    }
}
