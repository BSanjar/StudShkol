using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.StudentTests
{
    public class Details
    {
        public class Query : IRequest<StudentTest>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, StudentTest>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<StudentTest> Handle(Query request, CancellationToken cancellationToken)
            {
                var studentTest = await _context.StudentTest.FindAsync(request.Id);
                if (studentTest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { studentTest = "not found" });
                return studentTest;
            }
        }
    }
}