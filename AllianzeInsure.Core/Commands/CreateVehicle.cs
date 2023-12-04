using AllianzeInsure.Core.Common;
using MediatR;

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
            public CreateVehicleHandler()
            {

            }
            public Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
