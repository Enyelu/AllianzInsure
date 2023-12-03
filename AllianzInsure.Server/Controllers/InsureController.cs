using AutoMapper;
using Microsoft.AspNetCore.Mvc;

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
    }
}
