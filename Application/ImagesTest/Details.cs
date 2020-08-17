using MediatR;
using Domain;
using System;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Application.Errors;
using System.Net;

namespace Application.ImagesTest
{
    public class Details
    {
        public class Query : IRequest<ImageTest>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ImageTest>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }


            public async Task<ImageTest> Handle(Query request, CancellationToken cancellationToken)
            {
                var imagetest = await _context.ImageTest.FindAsync(request.Id);
                if (imagetest == null)
                    throw new RestException(HttpStatusCode.NotFound, new { imagetest = "not found" });
                return imagetest;
            }
        }
    }
}