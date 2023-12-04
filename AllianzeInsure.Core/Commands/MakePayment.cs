using AllianzeInsure.Core.Common;
using AllianzeInsure.Data.Entities;
using AllianzInsure.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using PayStack.Net;
using System.Net.Http;
using System.Security.Claims;

namespace AllianzeInsure.Core.Commands
{
    public class MakePayment
    {
        public class Command : IRequest<GenericResponse<string>>
        {
            public string InsuranceId { get; set; }
            public string CustomerFirstName { get; set; }
            public string CustomerLastName { get; set; }
            public string CustomerEmail { get; set; }
            public string PaymentType { get; set; }
            public int Amount { get; set; }
        }

        public class MakePaymentHandler : IRequestHandler<Command, GenericResponse<string>>
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
            public async Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var random = new Random();
                var transactionRef = random.Next(111111, 999999999).ToString();

                TransactionInitializeRequest req = new TransactionInitializeRequest
                {
                    AmountInKobo = request.Amount * 100,
                    Currency = "NGN",
                    Email = request.CustomerEmail,
                    CallbackUrl = $"{_configuration["AppUrl"]}/api/Payment/Verify/",
                    Reference = transactionRef
                };

                TransactionInitializeResponse response = PayStack.Transactions.Initialize(req);

                if (response.Status)
                {
                    Payment payment = new Payment()
                    {
                        InsuranceId = request.InsuranceId,
                        CustomerFirstName = request.CustomerFirstName,
                        CustomerLastName = request.CustomerLastName,
                        CustomerEmail = request.CustomerEmail,
                        PaymentType = request.PaymentType,
                        Amount = request.Amount,
                        TransactionReference = transactionRef,
                        CreatedBy = "Test User",
                        ModifiedBy = "Test User"
                    };

                
                    await _context.Payments.AddAsync(payment);
                    await _context.SaveChangesAsync();
                    return GenericResponse<string>.Success($"{response.Data.AuthorizationUrl}", "Successful");
                }
                return GenericResponse<string>.Fail("Failed");
            }
        }
    }
}