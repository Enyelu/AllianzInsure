using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AllianzInsure.Server.Controllers
{
    public class VehiclesController : BaseController
    {
        private readonly IMapper _mapper;
        public VehiclesController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Vehicles(CreateVehicleDto command)
        {
            var mappedResult = _mapper.Map<CreateVehicle.Command>(command);
            var response = await Mediator.Send(mappedResult);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<VehicleResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FetchVehicles([FromQuery] string? id)
        {
            var response = await Mediator.Send(new FetchVehicles.Query { Id = id});
            return Ok(response);
        }
    }
}