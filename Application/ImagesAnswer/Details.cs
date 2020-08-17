using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.ImagesAnswer
{
    public class Details
    {
        public class Query : IRequest<ImageAnswer>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ImageAnswer>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<ImageAnswer> Handle(Query request, CancellationToken cancellationToken)
            {
                var imageanswer = await _context.ImageAnswer.FindAsync(request.Id);
                if (imageanswer == null)
                    throw new RestException(HttpStatusCode.NotFound, new { imageanswer = "not found" });
                return imageanswer;
            }
        }
    }
}