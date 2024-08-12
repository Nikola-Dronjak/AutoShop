using AutoShop.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.ViewModel
{
    public class CarListingFilterVM
    {
        [ValidateNever]
        public CarListing? CarListing { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? EngineTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? TransmissionTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? FuelTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? BodyTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ModelOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? ModelOptionsForSelectedBrand { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem>? BrandOptions { get; set; }

        [ValidateNever]
        public int? SelectedBrandId { get; set; }

        [ValidateNever]
        public List<int>? SelectedModelIds { get; set; }

        [ValidateNever]
        public List<int>? SelectedEngineTypeIds { get; set; }

        [ValidateNever]
        public List<int>? SelectedTransmissionTypeIds { get; set; }

        [ValidateNever]
        public List<int>? SelectedBodyTypeIds { get; set; }

        [ValidateNever]
        public List<int>? SelectedFuelTypeIds { get; set; }

        [Range(1950, 2025, ErrorMessage = "Start year must be between 1950 and 2025.")]
        public int? YearFrom { get; set; }

        [Range(1950,2025, ErrorMessage = "End year must be between 1950 and 2025.")]
        [GreaterThanIfBothSpecified("YearFrom", ErrorMessage = "End year must be greater than the start year.")]
        public int? YearTo { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
        public int? Price { get; set; }
    }
}
