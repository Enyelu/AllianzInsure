using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzInsure.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Queries
{
    public class FetchPayments
    {
        public class Query : IRequest<GenericResponse<List<PaymentResponse>>>
        {
            public string? Id { get; set; }

        }

        public class MakePaymentHandler : IRequestHandler<Query, GenericResponse<List<PaymentResponse>>>
        {
            private readonly ApplicationContext _context;
            private readonly IMapper _mapper;
            public MakePaymentHandler(IMapper mapper, ApplicationContext context)
            {
                _mapper = mapper;
                _context = context;
            }
            public async Task<GenericResponse<List<PaymentResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request?.Id))
                {
                    var payments = await _context.Payments.Where(x => x.Id == request.Id).ToListAsync();

                    if (payments == null)
                    {
                        return GenericResponse<List<PaymentResponse>>.NotFound($"Payment with Id {request.Id} was not found");
                    }
                    return GenericResponse<List<PaymentResponse>>.Success(_mapper.Map<List<PaymentResponse>>(payments), "Successful");
                }

                var paymt = await _context.Payments.ToListAsync();
                if (paymt.Count <= 0)
                {
                    return GenericResponse<List<PaymentResponse>>.NotFound($"No payment found");
                }
                return GenericResponse<List<PaymentResponse>>.Success(_mapper.Map<List<PaymentResponse>>(paymt), "Successful");
            }
        }
    }
}
