using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.LevelTests
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public Guid groupTestId { get; set; }
            public string TimeToTest { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.groupTestId).NotEmpty();
                RuleFor(x => x.TimeToTest).NotEmpty();
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
                var leveltest = await _context.LevelTest.FindAsync(request.Id);

                if (leveltest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { leveltest = "not found" });

                leveltest.Name = request.Name ?? leveltest.Name;
                leveltest.groupTestId = request.groupTestId;
                leveltest.TimeToTest = request.TimeToTest;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}