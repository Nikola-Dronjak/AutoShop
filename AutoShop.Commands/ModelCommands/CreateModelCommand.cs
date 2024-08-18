using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ModelCommands
{
    public class CreateModelCommand : IRequest
    {
        public Model Model { get; set; }

        public CreateModelCommand(Model model)
        {
            Model = model;
        }
    }
}
