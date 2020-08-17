using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.GroupTests
{
    public class List
    {
        public class Query : IRequest<List<GroupTest>> { }
        public class Handler : IRequestHandler<Query, List<GroupTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<GroupTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var groupTests = await _context.GroupTest.ToListAsync();
                return groupTests;
            }
        }
    }
}