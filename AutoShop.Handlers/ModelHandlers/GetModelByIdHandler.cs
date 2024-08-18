using AutoShop.Domain;
using AutoShop.Queries.ModelQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ModelHandlers
{
    public class GetModelByIdHandler : IRequestHandler<GetModelByIdQuery, Model>
    {
        private readonly IModelService _modelService;

        public GetModelByIdHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public Task<Model> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            Model model = _modelService.Get(request.Id);
            return Task.FromResult(model);
        }
    }
}
