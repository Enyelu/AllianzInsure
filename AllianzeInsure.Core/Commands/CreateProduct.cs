using AllianzeInsure.Core.Common;
using MediatR;

namespace AllianzeInsure.Core.Commands
{
    public class CreateProduct
    {
        public class Command : IRequest<GenericResponse<string>>
        {
            public string? BodyTpe { get; set; }
            public decimal Premium { get; set; }
            public decimal Discount { get; set; }
        }

        public class CreateProductHandler : IRequestHandler<Command, GenericResponse<string>>
        {
            public CreateProductHandler()
            {

            }
            public Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}