using AllianzeInsure.Core.Common;
using AllianzeInsure.Core.DTO;
using AllianzInsure.Infrastructure;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Queries
{
    public class FetchProducts
    {
        public class Query : IRequest<GenericResponse<List<ProductResponse>>>
        {
            public string? Id { get; set; }
        }

        public class FetchProductHandler : IRequestHandler<Query, GenericResponse<List<ProductResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly ApplicationContext _context;
            public FetchProductHandler(IMapper mapper, ApplicationContext context)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GenericResponse<List<ProductResponse>>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (!string.IsNullOrEmpty(request?.Id))
                {
                    var product = await _context.Products.Where(x => x.Id == request.Id).ToListAsync();

                    if (product == null)
                    {
                        return GenericResponse<List<ProductResponse>>.NotFound($"Product with Id {request.Id} was not found");
                    }
                    return GenericResponse<List<ProductResponse>>.Success(_mapper.Map<List<ProductResponse>>(product), "Successful");
                }

                var prdt = await _context.Insurances.ToListAsync();
                if (prdt.Count <= 0)
                {
                    return GenericResponse<List<ProductResponse>>.NotFound($"No Product found");
                }
                return GenericResponse<List<ProductResponse>>.Success(_mapper.Map<List<ProductResponse>>(prdt), "Successful");
            }
        }
    }
}