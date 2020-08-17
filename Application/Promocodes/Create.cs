using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;

namespace Application.Promocodes
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }
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
                var promocode = new Promocode
                {
                    code = request.code,
                    dateCreate = request.dateCreate,
                    dateFinishUsing = request.dateFinishUsing,
                    dateStartUsing = request.dateStartUsing,
                    status = request.status
                };

                _context.Promocode.Add(promocode);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}