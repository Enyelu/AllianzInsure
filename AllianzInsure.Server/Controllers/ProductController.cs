using AllianzeInsure.Core.Commands;
using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzeInsure.Core.Queries;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AllianzInsure.Server.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IMapper _mapper;
        public ProductController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericResponse<string>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Product(CreateProductDto command)
        {
            var mappedRequest = _mapper.Map<CreateProduct.Command>(command);
            var response = await Mediator.Send(mappedRequest);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GenericResponse<List<ProductResponse>>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> FetchProduct([FromQuery] string? id)
        {
            var response = await Mediator.Send(new FetchProducts.Query { Id = id});
            return Ok(response);
        }
    }
}
