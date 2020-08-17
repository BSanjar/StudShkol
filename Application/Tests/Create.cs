using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.Tests
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }
            public string Question { get; set; }
            public Guid levelTestId { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Question).NotEmpty();
                RuleFor(x => x.levelTestId).NotEmpty();
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
                var test = new Test
                {
                    Id = request.id,
                    Question = request.Question,
                    levelTestId = request.levelTestId
                };

                _context.Test.Add(test);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}