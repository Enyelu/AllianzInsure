using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using MediatR;

namespace AllianzeInsure.Core.Queries
{
    public class FetchVehicles
    {
        public class Query : IRequest<GenericResponse<VehicleResponse>>
        {
            public string? Id { get; set; }
        }

        public class FetchVehiclesHandler : IRequestHandler<Query, GenericResponse<VehicleResponse>>
        {
            public FetchVehiclesHandler()
            {

            }
            public Task<GenericResponse<VehicleResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
