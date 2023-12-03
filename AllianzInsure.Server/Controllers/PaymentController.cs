using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AllianzInsure.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : BaseController
    {
        private readonly IMapper _mapper;
        public PaymentController(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
