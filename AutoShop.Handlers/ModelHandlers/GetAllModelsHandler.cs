using AutoShop.Domain;
using AutoShop.Queries.ModelQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.ModelHandlers
{
    public class GetAllModelsHandler : IRequestHandler<GetAllModelsQuery, IEnumerable<Model>>
    {
        private readonly IModelService _modelService;

        public GetAllModelsHandler(IModelService modelService)
        {
            _modelService = modelService;
        }

        public Task<IEnumerable<Model>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Model> models = _modelService.Models;
            return Task.FromResult(models);
        }
    }
}
