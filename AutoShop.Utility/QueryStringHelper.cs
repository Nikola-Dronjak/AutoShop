using AutoShop.ViewModel;

namespace AutoShop.Utility
{
    public static class QueryStringHelper
    {
        public static string BuildQueryString(CarListingFilterVM searchCriteria, int pageIndex)
        {
            var queryString = new List<string>();

            if (pageIndex > 0)
            {
                queryString.Add($"page={pageIndex}");
            }

            if (searchCriteria.SelectedBrandId != null)
            {
                queryString.Add($"SelectedBrandId={searchCriteria.SelectedBrandId}");
            }

            if (searchCriteria.SelectedModelIds != null)
            {
                foreach (var modelId in searchCriteria.SelectedModelIds)
                {
                    queryString.Add($"SelectedModelIds={modelId}");
                }
            }

            if (searchCriteria.SelectedEngineTypeIds != null)
            {
                foreach (var engineTypeId in searchCriteria.SelectedEngineTypeIds)
                {
                    queryString.Add($"SelectedEngineTypeIds={engineTypeId}");
                }
            }

            if (searchCriteria.SelectedTransmissionTypeIds != null)
            {
                foreach (var transmissionTypeId in searchCriteria.SelectedTransmissionTypeIds)
                {
                    queryString.Add($"SelectedTransmissionTypeIds={transmissionTypeId}");
                }
            }

            if (searchCriteria.SelectedFuelTypeIds != null)
            {
                foreach (var fuelTypeId in searchCriteria.SelectedFuelTypeIds)
                {
                    queryString.Add($"SelectedFuelTypeIds={fuelTypeId}");
                }
            }

            if (searchCriteria.SelectedBodyTypeIds != null)
            {
                foreach (var bodyTypeId in searchCriteria.SelectedBodyTypeIds)
                {
                    queryString.Add($"SelectedBodyTypeIds={bodyTypeId}");
                }
            }

            if (searchCriteria.Price.HasValue)
            {
                queryString.Add($"Price={searchCriteria.Price.Value}");
            }

            if (searchCriteria.YearFrom.HasValue)
            {
                queryString.Add($"YearFrom={searchCriteria.YearFrom.Value}");
            }

            if (searchCriteria.YearTo.HasValue)
            {
                queryString.Add($"YearTo={searchCriteria.YearTo.Value}");
            }

            return string.Join("&", queryString.ToArray());
        }
    }
}
