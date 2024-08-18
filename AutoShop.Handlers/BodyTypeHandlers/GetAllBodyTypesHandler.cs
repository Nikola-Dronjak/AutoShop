using AutoShop.Domain;
using AutoShop.Queries.BodyTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BodyTypeHandlers
{
    public class GetAllBodyTypesHandler : IRequestHandler<GetAllBodyTypesQuery, IEnumerable<BodyType>>
    {
        private readonly IBodyTypeService _bodyTypeService;

        public GetAllBodyTypesHandler(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        public Task<IEnumerable<BodyType>> Handle(GetAllBodyTypesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<BodyType> bodyTypes = _bodyTypeService.BodyTypes;
            return Task.FromResult(bodyTypes);
        }
    }
}
