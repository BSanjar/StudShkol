using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.GroupTests
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }
            public string name { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.name).NotEmpty();
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
                var groupTest = await _context.GroupTest.FindAsync(request.id);

                if (groupTest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { activity = "not found" });

                groupTest.Name = request.name ?? groupTest.Name;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}