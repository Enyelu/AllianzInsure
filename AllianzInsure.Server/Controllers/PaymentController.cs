using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PayStack.Net;
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

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Payment(MakePayment.Command command)
        {
            var response = await Mediator.Send(command);
            return Ok(response);
        }

        [HttpGet("History")]
        [ProducesResponseType(typeof(GenericResponse<List<PaymentResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FetchPaymentHistory([FromQuery] string? id)
        {
            var response = await Mediator.Send(new FetchPayments.Query { Id = id});
            return Ok(response);
        }

        [HttpGet("Verify")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Verify(string reference)
        {
            var response = await Mediator.Send(new VerifyPayment.Command { Reference = reference });
            return Ok(response);
        }
    }
}