using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.GroupTests
{
    public class Details
    {
        public class Query : IRequest<GroupTest>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GroupTest>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<GroupTest> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.GroupTest.FindAsync(request.Id);
                if (activity == null)
                    throw new RestException(HttpStatusCode.NotFound, new { activity = "not found" });
                return activity;
            }
        }
    }
}