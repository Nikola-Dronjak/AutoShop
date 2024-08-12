using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Brand name cannot be empty.")]
        [DisplayName("Brand:")]
        public string? Name { get; set; }

        public ICollection<Model>? Models { get; set; }
    }
}
