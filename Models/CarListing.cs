using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoShop.Domain
{
    public enum CarColor
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Black,
        Gray,
        White,
        Other
    }

    public enum CarDoors
    {
        Three,
        Five
    }

    public enum CarStatus
    {
        Active,
        Archived
    }

    public class CarListing
    {
        [Key]
        public int CarId { get; set; }

        [ValidateNever]
        public string? UserId { get; set; }

        [Required(ErrorMessage = "Brand name cannot be empty.")]
        [DisplayName("Brand:")]
        public string? BrandName { get; set; }

        [Required(ErrorMessage = "Model name cannot be empty.")]
        public int ModelId { get; set; }

        [ForeignKey("ModelId")]
        [DisplayName("Model:")]
        [ValidateNever]
        public Model? Model { get; set; }

        [Required(ErrorMessage = "Year cannot be empty.")]
        [Range(1950, 2025, ErrorMessage = "Year must be between 1950 and 2025.")]
        [DisplayName("Year:")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Color cannot be empty.")]
        [DisplayName("Color:")]
        public CarColor Color { get; set; }

        [Required(ErrorMessage = "Engine type cannot be empty.")]
        public int EngineTypeId { get; set; }

        [ForeignKey("EngineTypeId")]
        [DisplayName("Engine type:")]
        [ValidateNever]
        public EngineType? EngineType { get; set; }

        [Required(ErrorMessage = "Transmission type cannot be empty.")]
        public int TransmissionTypeId { get; set; }

        [ForeignKey("TransmissionTypeId")]
        [DisplayName("Transmission type:")]
        [ValidateNever]
        public TransmissionType? TransmissionType { get; set; }

        [Required(ErrorMessage = "Fuel type cannot be empty.")]
        public int FuelTypeId { get; set; }

        [ForeignKey("FuelTypeId")]
        [DisplayName("Fuel type:")]
        [ValidateNever]
        public FuelType? FuelType { get; set; }

        [Required(ErrorMessage = "Body type cannot be empty.")]
        public int BodyTypeId { get; set; }

        [ForeignKey("BodyTypeId")]
        [DisplayName("Body type:")]
        [ValidateNever]
        public BodyType? BodyType { get; set; }

        [Required(ErrorMessage = "Mileage cannot be empty.")]
        [Range(0, int.MaxValue, ErrorMessage = "Mileage must be a positive value.")]
        [DisplayName("Mileage:")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Price cannot be empty.")]
        [Range(0, int.MaxValue, ErrorMessage = "Price must be a positive value.")]
        [DisplayName("Price:")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Number of doors cannot be empty.")]
        [DisplayName("Number of doors:")]
        public CarDoors NumberOfDoors { get; set; }

        [Required(ErrorMessage = "Number of seats cannot be empty.")]
        [Range(2, 9, ErrorMessage = "A car cant have less than 2 or more than 9 seats.")]
        [DisplayName("Number of seats:")]
        public int NumberOfSeats { get; set; }

        [Required(ErrorMessage = "Vehicle identification number cannot be empty.")]
        [DisplayName("Vehicle Identification Number:")]
        public string? VIN { get; set; }

        [Required(ErrorMessage = "Description cannot be empty.")]
        [DisplayName("Description:")]
        public string? Description { get; set; }

        [DisplayName("Images:")]
        public ICollection<Image>? Images { get; set; }

        [DisplayName("Status:")]
        [ValidateNever]
        public CarStatus Status { get; set; }
    }
}
