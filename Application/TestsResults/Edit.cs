using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.TestsResults
{
    public class Edit
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
                var testResult = await _context.TestResult.FindAsync(request.Id);

                if (testResult == null)
                    throw new RestException(HttpStatusCode.NotFound, new { answer = "not found" });

                // answer.answer = request.answer ?? answer.answer;
                // answer.score = request.testsId ?? answer.testsId;
                // answer.score = request.score ?? answer.score;

                testResult.studentTestId = request.studentTestId;
                testResult.testId = request.testId;
                testResult.answerId = request.answerId;
                testResult.Comment = request.Comment;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}