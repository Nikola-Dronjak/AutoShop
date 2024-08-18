using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.FuelTypeQueries
{
    public class GetAllFuelTypesQuery : IRequest<IEnumerable<FuelType>>
    {
        public GetAllFuelTypesQuery()
        {

        }
    }
}
