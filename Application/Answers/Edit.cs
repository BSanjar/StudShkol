using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Answers
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public int answer { get; set; }
            public Guid testsId { get; set; }
            public int score { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.answer).NotEmpty();
                RuleFor(x => x.score).NotEmpty();
                RuleFor(x => x.testsId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var answer = await _context.Answer.FindAsync(request.Id);

                if (answer == null)
                    throw new RestException(HttpStatusCode.NotFound, new { answer = "not found" });

                // answer.answer = request.answer ?? answer.answer;
                // answer.score = request.testsId ?? answer.testsId;
                // answer.score = request.score ?? answer.score;

                answer.answer = request.answer;
                answer.score = request.score;
                answer.testsId = request.testsId;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}