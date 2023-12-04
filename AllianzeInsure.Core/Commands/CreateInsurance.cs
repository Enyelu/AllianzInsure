using AllianzeInsure.Core.Common;
using MediatR;

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
            public CreateInsuranceHandler()
            {
                    
            }
            public Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}