using AutoShop.Domain;
using MediatR;

namespace AutoShop.Commands.ModelCommands
{
    public class DeleteModelCommand : IRequest
    {
        public Model Model { get; set; }

        public DeleteModelCommand(Model model)
        {
            Model = model;
        }
    }
}
