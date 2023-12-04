using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AllianzInsure.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsureController : BaseController
    {
        private readonly IMapper _mapper;
        public InsureController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("Insurance")]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public IActionResult Insurance(CreateInsuranceDto command)
        {
            var mappedRequest = _mapper.Map<CreateInsurance.Command>(command);
            var response = Mediator.Send(mappedRequest);
            return Ok(response);
        }

        [HttpGet("FetchInsurance")]
        [ProducesResponseType(typeof(GenericResponse<FetchInsurance.Result>), (int)HttpStatusCode.OK)]
        public IActionResult FetchInsurance([FromQuery]string? id)
        {
            var response = Mediator.Send(new FetchInsurance.Query { Id = id});
            return Ok(response);
        }
    }
}