using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.BrandCommands
{
    public class DeleteBrandCommand : IRequest
    {
        public Brand Brand { get; set; }

        public DeleteBrandCommand(Brand brand)
        {
            Brand = brand;
        }
    }
}
