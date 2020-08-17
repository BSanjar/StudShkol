using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using MediatR;
using Persistence;

namespace Application.ImagesTest
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid id { get; set; }
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
                var imagetest = await _context.ImageTest.FindAsync(request.id);
                if(imagetest==null)
                    throw new RestException(HttpStatusCode.NotFound, new {imagetest="not found"});
                
                _context.Remove(imagetest);
                var success = await _context.SaveChangesAsync() > 0;
                if (success)
                    return Unit.Value;
                throw new Exception("Problem saving changes");
            }
        }
    }
}