using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Application.StudentTests
{
    public class ListByGroupAndStudent
    {
        public class Query : IRequest<List<StudentTest>>
        {
            public Guid groupId { get; set; }
            public Guid studentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<StudentTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            //тесты студентов которые входят в группу
            public async Task<List<StudentTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studentTests = await _context.StudentTest.Where(a => a.studentId == request.studentId).ToListAsync();
                List<StudentTest> studenttests = new List<StudentTest>();
                var levels = await
                    _context.LevelTest.Where(a => a.groupTestId == request.groupId).ToListAsync();
                foreach (var i in studentTests)
                {
                    if (levels.Count(a => a.Id == i.levelTestId) > 0)
                    {
                        studenttests.Add(i);
                    }
                }
                //var levels = await _context.StudentTest.Where(a=>a.studentId==request.studentId).ToListAsync();
                return studenttests;
            }
        }
    }
}