using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BrandCommands
{
    public class CreateBrandCommand : IRequest
    {
        public Brand Brand { get; set; }

        public CreateBrandCommand(Brand brand)
        {
            Brand = brand;
        }
    }
}
