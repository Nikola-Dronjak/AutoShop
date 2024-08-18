using AutoShop.Domain;
using AutoShop.Queries.BodyTypeQueries;
using AutoShop.Services.Interfaces;
using MediatR;

namespace AutoShop.Handlers.BodyTypeHandlers
{
    public class GetBodyTypeByIdHandler : IRequestHandler<GetBodyTypeByIdQuery, BodyType>
    {
        private readonly IBodyTypeService _bodyTypeService;

        public GetBodyTypeByIdHandler(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }

        public Task<BodyType> Handle(GetBodyTypeByIdQuery request, CancellationToken cancellationToken)
        {
            BodyType bodyType = _bodyTypeService.Get(request.Id);
            return Task.FromResult(bodyType);
        }
    }
}
