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
    public class ListByGroupAndStudent
    {
        public class Query : IRequest<List<LevelTest>>
        {
            public Guid groupId { get; set; }
            public Guid studentId { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<LevelTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<LevelTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var leveltests = await _context.LevelTest.Where(a => a.groupTestId == request.groupId).ToListAsync();
                var studentTests = await _context.StudentTest.Where(a => a.studentId == request.studentId).ToListAsync();
                List<LevelTest> levelTests = new List<LevelTest>();
                foreach (var i in leveltests)
                {
                    if (studentTests.Count(a => a.levelTestId == i.Id) > 0)
                    {
                        foreach (var j in studentTests.Where(a => a.levelTestId == i.Id))
                        {
                            // var lev = i;
                            // lev.studentTestId = j.Id.ToString();
                            levelTests.Add(i);
                        }
                    }
                }
                return levelTests;
            }
        }
    }
}