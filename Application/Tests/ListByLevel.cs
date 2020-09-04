using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Application.Tests
{
    public class ListByLevel
    {
        public class Query : IRequest<List<Test>>
        {
            public Guid levelId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<Test>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Test>> Handle(Query request, CancellationToken cancellationToken)
            {
                var tests = await _context.Test.Where(a=>a.levelTestId==request.levelId).ToListAsync();
                return tests;
            }
        }
    }
}