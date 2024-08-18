using AutoShop.Domain;
using AutoShop.Queries.EngineTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.EngineTypeHandlers
{
    public class GetAllEngineTypesHandler : IRequestHandler<GetAllEngineTypesQuery, IEnumerable<EngineType>>
    {
        private readonly IEngineTypeService _engineTypeService;

        public GetAllEngineTypesHandler(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        public Task<IEnumerable<EngineType>> Handle(GetAllEngineTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<EngineType> engineTypes = _engineTypeService.EngineTypes;
            return Task.FromResult(engineTypes);
        }
    }
}
