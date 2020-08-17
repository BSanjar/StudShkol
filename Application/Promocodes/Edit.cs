using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using FluentValidation;
using MediatR;
using Persistence;

namespace Application.Promocodes
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string code { get; set; }
            public DateTime dateCreate { get; set; }
            public string status { get; set; }//wait, in process, processed
            public DateTime dateStartUsing { get; set; }
            public DateTime dateFinishUsing { get; set; }

        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.code).NotEmpty();
                RuleFor(x => x.dateCreate).NotEmpty();
                RuleFor(x => x.dateFinishUsing).NotEmpty();
                RuleFor(x => x.dateStartUsing).NotEmpty();
                RuleFor(x => x.status).NotEmpty();

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
                var promocode = await _context.Promocode.FindAsync(request.Id);

                if (promocode == null)
                    throw new RestException(HttpStatusCode.NotFound, new { answer = "not found" });

                // answer.answer = request.answer ?? answer.answer;
                // answer.score = request.testsId ?? answer.testsId;
                // answer.score = request.score ?? answer.score;

                promocode.code = request.code;
                promocode.dateCreate = request.dateCreate;
                promocode.dateFinishUsing = request.dateFinishUsing;
                promocode.dateStartUsing = request.dateStartUsing;
                promocode.status = request.status;
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");

            }
        }
    }
}