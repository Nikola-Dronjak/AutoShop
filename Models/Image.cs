using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShop.Domain
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        [Required(ErrorMessage = "ImageUrl cannot be empty.")]
        public string? ImageUrl { get; set; }

        [Required]
        public int CarId { get; set; }

        [ForeignKey("CarId")]
        [ValidateNever]
        public CarListing? CarListing { get; set; }
    }
}
