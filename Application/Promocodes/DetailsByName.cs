using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Promocodes
{
    public class DetailsByName
    {
        public class Query : IRequest<Promocode>
        {
            public string code { get; set; }
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
                var promocode = await _context.Promocode.FirstOrDefaultAsync(a=>a.code==request.code);
                if (promocode == null)
                    throw new RestException(HttpStatusCode.NotFound, new { promocode = "not found" });
                return promocode;
            }
        }
    }
}