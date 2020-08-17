using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.LevelTests
{
    public class List
    {
        public class Query : IRequest<List<LevelTest>> { }
        public class Handler : IRequestHandler<Query, List<LevelTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<LevelTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var leveltest = await _context.LevelTest.ToListAsync();
                return leveltest;
            }
        }
    }
}