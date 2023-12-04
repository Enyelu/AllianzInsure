using AllianzeInsure.Core.Common;
using MediatR;

namespace AllianzeInsure.Core.Queries
{
    public class FetchInsurance
    {
        public class Query : IRequest<GenericResponse<Result>>
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

        public class FetchInsuranceHandler : IRequestHandler<Query, GenericResponse<Result>>
        {
            public FetchInsuranceHandler()
            {

            }
            public Task<GenericResponse<Result>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
