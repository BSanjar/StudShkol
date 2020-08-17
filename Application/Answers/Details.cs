using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.Answers
{
    public class Details
    {
        public class Query : IRequest<Answer>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Answer>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Answer> Handle(Query request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answer.FindAsync(request.Id);
                if (answer == null)
                    throw new RestException(HttpStatusCode.NotFound, new { answer = "not found" });
                return answer;
            }
        }
    }
}