using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.StudentTests
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid studentId { get; set; }
            public Guid levelTestId { get; set; }
            public Guid codeId { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.studentId).NotEmpty();
                RuleFor(x => x.levelTestId).NotEmpty();
                RuleFor(x => x.codeId).NotEmpty();
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
                var studentTest = await _context.StudentTest.FindAsync(request.Id);

                if (studentTest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { answer = "not found" });

                // answer.answer = request.answer ?? answer.answer;
                // answer.score = request.testsId ?? answer.testsId;
                // answer.score = request.score ?? answer.score;

                studentTest.studentId = request.studentId;
                studentTest.levelTestId = request.levelTestId;
                studentTest.codeId = request.codeId;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}