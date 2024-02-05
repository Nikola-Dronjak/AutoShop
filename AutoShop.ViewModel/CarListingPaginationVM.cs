using AutoShop.Domain;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AutoShop.ViewModel
{
    public class CarListingPaginationVM
    {
        [ValidateNever]
        public IEnumerable<CarListing> CarListings { get; set; }

        [ValidateNever]
        public int TotalPages { get; set; }

        [ValidateNever]
        public int PageIndex { get; set; }

        [ValidateNever]
        public bool HasPreviousPage { get; set; }

        [ValidateNever]
        public bool HasNextPage { get; set; }

        [ValidateNever]
        public CarListingFilterVM SearchCriteria { get; set; }
    }
}
