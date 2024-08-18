using AutoShop.Domain;
using AutoShop.Queries.FuelTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.FuelTypeHandlers
{
    public class GetAllFuelTypesHandler : IRequestHandler<GetAllFuelTypesQuery, IEnumerable<FuelType>>
    {
        private readonly IFuelTypeService _fuelTypeService;

        public GetAllFuelTypesHandler(IFuelTypeService fuelTypeService)
        {
            _fuelTypeService = fuelTypeService;
        }

        public Task<IEnumerable<FuelType>> Handle(GetAllFuelTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<FuelType> fuelTypes = _fuelTypeService.FuelTypes;
            return Task.FromResult(fuelTypes);
        }
    }
}
