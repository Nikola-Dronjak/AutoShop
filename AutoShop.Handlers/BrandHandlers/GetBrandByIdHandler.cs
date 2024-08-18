using AutoShop.Domain;
using AutoShop.Queries.BrandQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BrandHandlers
{
    public class GetBrandByIdHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        private readonly IBrandService _brandService;

        public GetBrandByIdHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            Brand brand = _brandService.Get(request.Id);
            return Task.FromResult(brand);
        }
    }
}
