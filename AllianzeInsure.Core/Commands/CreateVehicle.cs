using AllianzeInsure.Core.Common;
using AllianzeInsure.Data.Entities;
using AllianzInsure.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Commands
{
    public class CreateVehicle
    {
        public class Command : IRequest<GenericResponse<string>>
        {
            public string? Make { get; set; }
            public string? Model { get; set; }
            public int? Year { get; set; }
        }

        public class CreateVehicleHandler : IRequestHandler<Command, GenericResponse<string>>
        {
            private readonly ApplicationContext _context;
            public CreateVehicleHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var vehicle = new Vehicle
                {
                    Make = request.Make,
                    Model = request.Model,
                    Year = request.Year,
                    CreatedBy = "Test User",
                    ModifiedBy = "Test User"
                };
             
                await _context.Vehicles.AddAsync(vehicle, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return GenericResponse<string>.Success("Success", "Product was created successfully");
            }
        }
    }
}
