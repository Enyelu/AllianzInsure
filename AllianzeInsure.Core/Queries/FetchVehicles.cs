using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzInsure.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Queries
{
    public class FetchVehicles
    {
        public class Query : IRequest<GenericResponse<List<VehicleResponse>>>
        {
            public string? Id { get; set; }
        }

        public class FetchVehiclesHandler : IRequestHandler<Query, GenericResponse<List<VehicleResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly ApplicationContext _context;
            public FetchVehiclesHandler(ApplicationContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<GenericResponse<List<VehicleResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request?.Id))
                {
                    var vahicle = await _context.Vehicles.Where(x => x.Id == request.Id).ToListAsync();

                    if (vahicle == null)
                    {
                        return GenericResponse<List<VehicleResponse>>.NotFound($"Vahicle with Id {request.Id} was not found");
                    }
                    return GenericResponse<List<VehicleResponse>>.Success(_mapper.Map<List<VehicleResponse>>(vahicle), "Successful");
                }

                var vehicles = await _context.Vehicles.ToListAsync();
                if (vehicles.Count <= 0)
                {
                    return GenericResponse<List<VehicleResponse>>.NotFound($"No vehicle found");
                }
                return GenericResponse<List<VehicleResponse>>.Success(_mapper.Map<List<VehicleResponse>>(vehicles), "Successful");
            }
        }
    }
}
