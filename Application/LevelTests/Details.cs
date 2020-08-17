using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.LevelTests
{
    public class Details
    {
        public class Query : IRequest<LevelTest>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, LevelTest>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<LevelTest> Handle(Query request, CancellationToken cancellationToken)
            {
                var levelTest = await _context.LevelTest.FindAsync(request.Id);
                if (levelTest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { levelTest = "not found" });
                return levelTest;
            }
        }
    }
}