using AllianzInsure.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PayStack.Net;

namespace AllianzeInsure.Core.Commands
{
    public class VerifyPayment
    {
        public class Command : IRequest<string>
        {
            public string? Reference { get; set; }
        }

        public class MakePaymentHandler : IRequestHandler<Command, string>
        {
            private PayStackApi PayStack { get; set; }
            private string token;
            private readonly IConfiguration _configuration;
            private readonly ApplicationContext _context;
            public MakePaymentHandler(IConfiguration configuration, ApplicationContext context)
            {
                _context = context;
                _configuration = configuration;
                token = _configuration["Paystack:PaystackSK"];
                PayStack = new PayStackApi(token);
            }
            public async Task<string> Handle(Command request, CancellationToken cancellationToken)
            {
                var response = PayStack.Transactions.Verify(request.Reference);

                if (response.Data.Status.ToLower().Trim() == "success")
                {
                    var PaymentRecord = await _context.Payments.FirstOrDefaultAsync(x => x.TransactionReference == request.Reference);
                    if (PaymentRecord != null)
                    {
                        PaymentRecord.IsApproved = true;
                        _context.Payments.Update(PaymentRecord);
                        await _context.SaveChangesAsync();
                        return "Transaction successful";
                    }
                    return"Record not found";
                }
                return "Failed";
            }
        }
    }
}