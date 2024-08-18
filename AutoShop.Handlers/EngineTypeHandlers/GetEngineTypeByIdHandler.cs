using AutoShop.Domain;
using AutoShop.Queries.EngineTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.EngineTypeHandlers
{
    public class GetEngineTypeByIdHandler : IRequestHandler<GetEngineTypeByIdQuery, EngineType>
    {
        private readonly IEngineTypeService _engineTypeService;

        public GetEngineTypeByIdHandler(IEngineTypeService engineTypeService)
        {
            _engineTypeService = engineTypeService;
        }

        public Task<EngineType> Handle(GetEngineTypeByIdQuery request, CancellationToken cancellationToken)
        {
            EngineType engineType = _engineTypeService.Get(request.Id);
            return Task.FromResult(engineType);
        }
    }
}
