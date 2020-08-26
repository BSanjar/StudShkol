using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Application.GroupTests
{
    public class GroupsStudent
    {
        public class Query : IRequest<List<GroupTest>>
        {
            public Guid studentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<GroupTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<GroupTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var studentTests = await _context.StudentTest.Where(a => a.studentId == request.studentId).ToListAsync();
                List<GroupTest> groupsStudent = new List<GroupTest>();
                LevelTest levelTest = new LevelTest();
                foreach (var i in studentTests)
                {
                    levelTest = await _context.LevelTest.FirstOrDefaultAsync(a => a.Id == i.levelTestId);
                    var grs = await _context.GroupTest.FirstOrDefaultAsync(a => a.Id == levelTest.groupTestId);

                    if(grs!=null&&grs.Id.ToString()!=""&&groupsStudent.Count(a=>a.Id==grs.Id)==0)
                    groupsStudent.Add(await _context.GroupTest.FirstOrDefaultAsync(a => a.Id == levelTest.groupTestId));
                }
                return groupsStudent;
            }
        }
    }
}