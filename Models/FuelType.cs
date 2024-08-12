using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class FuelType
    {
        [Key]
        public int FuelTypeId { get; set; }

        [Required(ErrorMessage = "Fuel type cannot be empty.")]
        [DisplayName("Fuel type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
