using AutoShop.Queries.CarListingQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.CarListingHandlers
{
    public class GetTotalPagesHandler : IRequestHandler<GetTotalPagesQuery, int>
    {
        private readonly ICarListingService _carListingService;

        public GetTotalPagesHandler(ICarListingService carListingService)
        {
            _carListingService = carListingService;
        }

        public Task<int> Handle(GetTotalPagesQuery request, CancellationToken cancellationToken)
        {
            int totalPages = _carListingService.GetTotalPages(request.PageSize);
            return Task.FromResult(totalPages);
        }
    }
}
