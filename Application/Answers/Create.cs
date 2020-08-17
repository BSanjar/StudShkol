using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.Answers
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }
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
                var answer = new Answer
                {
                    Id = request.id,
                    score = request.score,
                    testsId = request.testsId,
                    answer = request.answer
                };

                _context.Answer.Add(answer);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}