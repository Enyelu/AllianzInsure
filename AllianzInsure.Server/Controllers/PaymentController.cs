using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PayStack.Net;
using System.Configuration;
using System.Net;

namespace AllianzInsure.Server.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IMapper _mapper;
        private PayStackApi PayStack { get; set; }
        private string token;
        private readonly IConfiguration _configuration;
        public PaymentController(IMapper mapper, IConfiguration configuration)
        {
            _configuration = configuration;
            token = _configuration["Paystack:PaystackSK"];
            PayStack = new PayStackApi(token);
            _mapper = mapper;
        }

        [HttpPost("Payment")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public IActionResult Payment(MakePayment.Command command)
        {
            var response = Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("PaymentHistory")]
        [ProducesResponseType(typeof(GenericResponse<List<PaymentResponse>>), (int)HttpStatusCode.OK)]
        public IActionResult FetchPaymentHistory([FromQuery] string id)
        {
            var response = Mediator.Send(new FetchPayments.Query { Id = id});
            return Ok(response);
        }

        [HttpGet("Verify")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Verify(string reference)
        {
            var response = Mediator.Send(new VerifyPayment.Command { Reference = reference });
            return Ok(response);
        }
    }
}