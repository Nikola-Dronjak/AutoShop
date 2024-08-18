using MediatR;

namespace AutoShop.Queries.CarListingQueries
{
    public class CheckVINExistsQuery : IRequest<bool>
    {
        public string VIN { get; }
        public int ExcludedCarId { get; }

        public CheckVINExistsQuery(string vin, int excludeCarId)
        {
            VIN = vin;
            ExcludedCarId = excludeCarId;
        }
    }
}
