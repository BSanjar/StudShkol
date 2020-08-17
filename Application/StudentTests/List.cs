using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.StudentTests
{
    public class List
    {
        public class Query : IRequest<List<StudentTest>> { }
        public class Handler : IRequestHandler<Query, List<StudentTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<StudentTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studentTests = await _context.StudentTest.ToListAsync();
                return studentTests;
            }
        }
    }
}