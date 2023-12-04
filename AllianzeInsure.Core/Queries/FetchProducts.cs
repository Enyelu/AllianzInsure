using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using MediatR;

namespace AllianzeInsure.Core.Queries
{
    public class FetchProducts
    {
        public class Query : IRequest<GenericResponse<ProductResponse>>
        {
            public string? Id { get; set; }
        }

        public class FetchProductHandler : IRequestHandler<Query, GenericResponse<ProductResponse>>
        {
            public FetchProductHandler()
            {
            }

            public Task<GenericResponse<ProductResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}