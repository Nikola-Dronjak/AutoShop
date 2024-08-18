using AutoShop.Domain;
using MediatR;

namespace AutoShop.Queries.FuelTypeQueries
{
    public class GetFuelTypeByIdQuery : IRequest<FuelType>
    {
        public int Id { get; set; }

        public GetFuelTypeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
