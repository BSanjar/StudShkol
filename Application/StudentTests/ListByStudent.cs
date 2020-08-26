using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using Application.Errors;
using System.Net;
using System.Linq;

namespace Application.StudentTests
{
    public class ListByStudent
    {
        public class Query : IRequest<List<StudentTest>> {  public Guid studentId { get; set; }}
        public class Handler : IRequestHandler<Query, List<StudentTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<StudentTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studentTests = await _context.StudentTest.Where(a=>a.studentId==request.studentId).ToListAsync();
                if (studentTests == null)
                    throw new RestException(HttpStatusCode.NotFound, new { studentTests = "not found" });
                return studentTests;
            }
        }
    }
}