using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.TestsResults
{
    public class Details
    {
        public class Query : IRequest<TestResult>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, TestResult>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<TestResult> Handle(Query request, CancellationToken cancellationToken)
            {
                var testResult = await _context.TestResult.FindAsync(request.Id);
                if (testResult == null)
                    throw new RestException(HttpStatusCode.NotFound, new { testResult = "not found" });
                return testResult;
            }
        }
    }
}