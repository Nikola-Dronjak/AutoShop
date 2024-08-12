using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class TransmissionType
    {
        [Key]
        public int TransmissionTypeId { get; set; }

        [Required(ErrorMessage = "Transmission type cannot be empty.")]
        [DisplayName("Transmission type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
