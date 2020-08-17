using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.TestsResults
{
    public class List
    {
        public class Query : IRequest<List<TestResult>> { }
        public class Handler : IRequestHandler<Query, List<TestResult>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<TestResult>> Handle(Query request, CancellationToken cancellationToken)
            {
                var testResults = await _context.TestResult.ToListAsync();
                return testResults;
            }
        }
    }
}