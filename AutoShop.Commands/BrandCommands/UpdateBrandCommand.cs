using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BrandCommands
{
    public class UpdateBrandCommand : IRequest
    {
        public Brand Brand { get; set; }

        public UpdateBrandCommand(Brand brand)
        {
            Brand = brand;
        }
    }
}
