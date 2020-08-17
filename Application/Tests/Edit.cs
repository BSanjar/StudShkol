using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Tests
{
    public class Edit
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
                var test = await _context.Test.FindAsync(request.id);

                if (test == null)
                    throw new RestException(HttpStatusCode.NotFound, new { test = "not found" });

                test.Question = request.Question ?? test.Question;
                test.levelTestId = request.levelTestId;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}