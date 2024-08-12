using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class BodyType
    {
        [Key]
        public int BodyTypeId { get; set; }

        [Required(ErrorMessage = "Body type cannot be empty.")]
        [DisplayName("Body type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
