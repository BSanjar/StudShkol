using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.Tests
{
    public class Details
    {
        public class Query : IRequest<Test>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Test>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<Test> Handle(Query request, CancellationToken cancellationToken)
            {
                var test = await _context.Test.FindAsync(request.Id);
                if (test == null)
                    throw new RestException(HttpStatusCode.NotFound, new { test = "not found" });
                return test;
            }
        }
    }
}