using AutoShop.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoShopWeb.ViewModels
{
    public class CarListingVM
    {
        [ValidateNever]
        public CarListing Car { get; set; }

        [ValidateNever]
        public string UserId { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> BrandOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> ModelOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> EngineTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> TransmissionTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> FuelTypeOptions { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> BodyTypeOptions { get; set; }
    }
}
