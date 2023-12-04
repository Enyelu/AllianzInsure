using AllianzeInsure.Core.Common;
using AllianzeInsure.Data.Entities;
using AllianzInsure.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AllianzeInsure.Core.Commands
{
    public class CreateProduct
    {
        public class Command : IRequest<GenericResponse<string>>
        {
            public string? BodyTpe { get; set; }
            public decimal Premium { get; set; }
            public decimal Discount { get; set; }
        }

        public class CreateProductHandler : IRequestHandler<Command, GenericResponse<string>>
        {
            private readonly ApplicationContext _context;
            public CreateProductHandler(ApplicationContext context)
            {
                _context = context;
            }
            public async Task<GenericResponse<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                var payment = new Product
                {
                    BodyTpe = request.BodyTpe,
                    Premium = request.Premium,
                    Discount = request.Discount,
                    CreatedBy = "Test User",
                    ModifiedBy = "Test User"
                };

                await _context.Products.AddAsync(payment, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);

                return GenericResponse<string>.Success("Success", "Product was created successfully");
            }
        }
    }
}