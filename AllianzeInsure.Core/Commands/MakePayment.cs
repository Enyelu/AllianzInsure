using AllianzeInsure.Core.Common;
using MediatR;

namespace AllianzeInsure.Core.Commands
{
    public class MakePayment
    {
        public class Command : IRequest<GenericResponse<string>>
        {
            public string PaymentType { get; set; }
            public string Email { get; set; }
            public int Amount { get; set; }
        }

        public class MakePaymentHandler : IRequestHandler<Command, GenericResponse<string>>
        {
            public Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}