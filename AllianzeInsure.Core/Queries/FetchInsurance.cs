using AllianzeInsure.Core.Common;
using AllianzeInsure.Data.Entities;
using AllianzInsure.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Queries
{
    public class FetchInsurance
    {
        public class Query : IRequest<GenericResponse<List<Result>>>
        {
            public string? Id { get; set; }
        }

        public class Result
        {
            public string? Id { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string? Email { get; set; }
            public string? PhoneNumber { get; set; }
            public string? VehicleMake { get; set; }
            public string? VehicleModel { get; set; }
            public string? RegistrationNumber { get; set; }
            public string? BodyType { get; set; }
        }

        public class FetchInsuranceHandler : IRequestHandler<Query, GenericResponse<List<Result>>>
        {
            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;
            public FetchInsuranceHandler(ApplicationContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<GenericResponse<List<Result>>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request?.Id))
                {
                    var insurance = await _context.Insurances.Where(x => x.Id == request.Id).ToListAsync();

                    if (insurance == null)
                    {
                        return GenericResponse<List<Result>>.NotFound($"Policy with Id {request.Id} was not found");
                    }
                    return GenericResponse<List<Result>>.Success(_mapper.Map<List<Result>>(insurance), "Successful");
                }

                var insur = await _context.Insurances.ToListAsync();
                if (insur.Count <= 0)
                {
                    return GenericResponse<List<Result>>.NotFound($"No Policy found");
                }
                return GenericResponse<List<Result>>.Success(_mapper.Map<List<Result>>(insur), "Successful");

            }
        }
    }
}
