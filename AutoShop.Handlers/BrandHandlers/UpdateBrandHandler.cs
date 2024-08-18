using AutoShop.Commands.BrandCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BrandHandlers
{
    public class UpdateBrandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IBrandService _brandService;

        public UpdateBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            _brandService.Update(request.Brand);
            return Task.CompletedTask;
        }
    }
}
