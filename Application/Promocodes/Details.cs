using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.Promocodes
{
    public class Details
    {
        public class Query : IRequest<Promocode>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Promocode>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Promocode> Handle(Query request, CancellationToken cancellationToken)
            {
                var promocode = await _context.Promocode.FindAsync(request.Id);
                if (promocode == null)
                    throw new RestException(HttpStatusCode.NotFound, new { promocode = "not found" });
                return promocode;
            }
        }
    }
}