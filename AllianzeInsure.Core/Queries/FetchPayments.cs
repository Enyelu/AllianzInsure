using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using MediatR;

namespace AllianzeInsure.Core.Queries
{
    public class FetchPayments
    {
        public class Query : IRequest<GenericResponse<PaymentResponse>>
        {
            public string? Id { get; set; }

        }

        public class MakePaymentHandler : IRequestHandler<Query, GenericResponse<PaymentResponse>>
        {
            public Task<GenericResponse<PaymentResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}
