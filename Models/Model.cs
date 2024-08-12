using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShop.Domain
{
    public class Model
    {
        [Key]
        public int ModelId { get; set; }

        [Required(ErrorMessage = "Model name cannot be empty.")]
        [DisplayName("Model:")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Brand name cannot be empty.")]
        public int BrandId { get; set; }

        [ForeignKey("BrandId")]
        [DisplayName("Brand:")]
        [ValidateNever]
        public Brand? Brand { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
