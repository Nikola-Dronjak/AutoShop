using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class EngineType
    {
        [Key]
        public int EngineTypeId { get; set; }

        [Required(ErrorMessage = "Type cannot be empty.")]
        [DisplayName("Type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
