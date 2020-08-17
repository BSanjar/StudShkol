using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.ImagesAnswer
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public Guid answerId { get; set; }
            public string file { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.answerId).NotEmpty();
                RuleFor(x => x.file).NotEmpty();
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
                var imageanswers = await _context.ImageAnswer.FindAsync(request.Id);

                if (imageanswers == null)
                    throw new RestException(HttpStatusCode.NotFound, new { imageanswers = "not found" });

                imageanswers.file = request.file ?? imageanswers.file;
                imageanswers.answerId = request.answerId;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}