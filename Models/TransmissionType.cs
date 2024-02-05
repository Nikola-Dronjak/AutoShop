using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AutoShop.Domain
{
    public class TransmissionType
    {
        [Key]
        public int TransmissionTypeId { get; set; }

        [Required(ErrorMessage = "Type cannot be empty.")]
        [DisplayName("Type:")]
        public string? Type { get; set; }

        public ICollection<CarListing>? CarListings { get; set; }
    }
}
