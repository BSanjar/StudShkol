using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Promocodes
{
    public class List
    {
        public class Query : IRequest<List<Promocode>> { }
        public class Handler : IRequestHandler<Query, List<Promocode>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Promocode>> Handle(Query request, CancellationToken cancellationToken)
            {
                var promocode = await _context.Promocode.ToListAsync();
                return promocode;
            }
        }
    }
}