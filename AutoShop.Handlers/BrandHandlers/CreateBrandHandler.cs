using AutoShop.Commands.BrandCommands;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BrandHandlers
{
    public class CreateBrandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IBrandService _brandService;

        public CreateBrandHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            _brandService.Add(request.Brand);
            return Task.CompletedTask;
        }
    }
}
