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

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Insurance(CreateInsuranceDto command)
        {
            var mappedRequest = _mapper.Map<CreateInsurance.Command>(command);
            var response = await Mediator.Send(mappedRequest);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<FetchInsurance.Result>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FetchInsurance([FromQuery]string? id)
        {
            var response = await Mediator.Send(new FetchInsurance.Query { Id = id});
            return Ok(response);
        }
    }
}