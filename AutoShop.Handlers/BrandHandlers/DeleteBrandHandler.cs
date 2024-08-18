using AutoShop.Commands.BrandCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BrandHandlers
{
    public class DeleteBrandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IBrandService _brandService;

        public DeleteBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            _brandService.Delete(request.Brand);
            return Task.CompletedTask;
        }
    }
}
