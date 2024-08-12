using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class EngineType
    {
        [Key]
        public int EngineTypeId { get; set; }

        [Required(ErrorMessage = "Engine type cannot be empty.")]
        [DisplayName("Engine type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
