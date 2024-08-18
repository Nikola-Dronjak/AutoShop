using AutoShop.Domain;
using AutoShop.Queries.BrandQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BrandHandlers
{
    public class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBrandService _brandService;

        public GetAllBrandsHandler(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Brand> brands = _brandService.Brands;
            return Task.FromResult(brands);
        }
    }
}
