using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Answers
{
    public class List
    {
        public class Query : IRequest<List<Answer>> { }
        public class Handler : IRequestHandler<Query, List<Answer>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Answer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answer.ToListAsync();
                return answer;
            }
        }
    }
}