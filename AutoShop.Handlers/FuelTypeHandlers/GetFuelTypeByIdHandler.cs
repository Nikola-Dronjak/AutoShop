using AutoShop.Domain;
using AutoShop.Queries.FuelTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.FuelTypeHandlers
{
    public class GetFuelTypeByIdHandler : IRequestHandler<GetFuelTypeByIdQuery, FuelType>
    {
        private readonly IFuelTypeService _fuelTypeService;

        public GetFuelTypeByIdHandler(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public Task<FuelType> Handle(GetFuelTypeByIdQuery request, CancellationToken cancellationToken)
        {
            FuelType fuelType = _fuelTypeService.Get(request.Id);
            return Task.FromResult(fuelType);
        }
    }
}
