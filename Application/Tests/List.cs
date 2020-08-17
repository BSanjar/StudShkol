using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests
{
    public class List
    {
        public class Query : IRequest<List<Test>> { }
        public class Handler : IRequestHandler<Query, List<Test>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Test>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tests = await _context.Test.ToListAsync();
                return tests;
            }
        }
    }
}