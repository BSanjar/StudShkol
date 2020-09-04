using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace Application.Answers
{
    public class ListByTest
    {
        public class Query : IRequest<List<Answer>>
        {
            public Guid test { get; set; }
        }
        public class Handler : IRequestHandler<Query, List<Answer>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Answer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answer.Where(a => a.testsId == request.test).ToListAsync();
                return answer;
            }
        }
    }
}