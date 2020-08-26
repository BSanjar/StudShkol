using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Application.Errors;
using System.Net;

namespace Application.LevelTests
{
    public class ListByGroup
    {
        public class Query : IRequest<List<LevelTest>> { public Guid groupId { get; set; } }
        public class Handler : IRequestHandler<Query, List<LevelTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<LevelTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var leveltest = await _context.LevelTest.Where(a => a.groupTestId == request.groupId).ToListAsync();
                if (leveltest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { studentTests = "not found" });
                return leveltest;
            }
        }
    }
}