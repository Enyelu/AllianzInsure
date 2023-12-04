using AllianzeInsure.Core.Common;
using AllianzeInsure.Data.Entities;
using AllianzInsure.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AllianzeInsure.Core.Commands
{
    public class CreateInsurance
    {
        public class Command : IRequest<GenericResponse<string>>
        {
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

        public class CreateInsuranceHandler : IRequestHandler<Command, GenericResponse<string>>
        {
            private readonly ApplicationContext _context;
            public CreateInsuranceHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var insurance = new Insurance
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    VehicleMake = request.VehicleMake,
                    VehicleModel = request.VehicleModel,
                    RegistrationNumber = request.RegistrationNumber,
                    BodyType = request.BodyType,
                };


                await _context.Insurances.AddAsync(insurance, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return GenericResponse<string>.Success("Success", "Policy was created successfully");
            }
        }
    }
}