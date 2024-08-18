using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ModelCommands
{
    public class UpdateModelCommand : IRequest
    {
        public Model Model { get; set; }

        public UpdateModelCommand(Model model)
        {
            Model = model;
        }
    }
}
