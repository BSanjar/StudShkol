using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.StudentTests
{
    public class Create
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
                var studentTest = new StudentTest
                {
                    Id = request.Id,
                    codeId = request.codeId,
                    levelTestId = request.levelTestId,
                    studentId = request.studentId
                };

                _context.StudentTest.Add(studentTest);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}