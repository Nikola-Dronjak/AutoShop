using AutoShop.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AutoShop.ViewModel
{
    public class CarListingDetailsVM
    {
        [ValidateNever]
        public CarListing? CarListing { get; set; }

        [ValidateNever]
        public string? UserEmail { get; set; }

        [ValidateNever]
        public string? UserPhoneNumber { get; set; }
    }
}
