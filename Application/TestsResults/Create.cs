using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.TestsResults
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid studentTestId { get; set; }
            public Guid testId { get; set; }
            public Guid answerId { get; set; }
            public string Comment { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.studentTestId).NotEmpty();
                RuleFor(x => x.testId).NotEmpty();
                RuleFor(x => x.answerId).NotEmpty();
                RuleFor(x => x.Comment).NotEmpty();
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
                var testResult = new TestResult
                {
                    Id = request.Id,
                    studentTestId = request.studentTestId,
                    testId = request.testId,
                    answerId = request.answerId,
                    Comment = request.Comment
                };

                _context.TestResult.Add(testResult);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}