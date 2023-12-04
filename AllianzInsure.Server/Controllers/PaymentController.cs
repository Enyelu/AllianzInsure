using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AllianzInsure.Server.Controllers
{
    public class PaymentController : BaseController
    {
        private readonly IMapper _mapper;
        public PaymentController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("Payment")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public IActionResult Payment()
        {
            var response = Mediator.Send(new MakePayment.Command());
            return Ok(response);
        }

        [HttpGet("PaymentHistory")]
        [ProducesResponseType(typeof(GenericResponse<PaymentResponse>), (int)HttpStatusCode.OK)]
        public IActionResult FetchPaymentHistory([FromQuery] string id)
        {
            var response = Mediator.Send(new FetchPayments.Query { Id = id});
            return Ok(response);
        }
    }
}