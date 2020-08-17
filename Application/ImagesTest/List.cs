using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.ImagesTest
{
    public class List
    {
        public class Query : IRequest<List<ImageTest>> { }
        public class Handler : IRequestHandler<Query, List<ImageTest>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ImageTest>> Handle(Query request, CancellationToken cancellationToken)
            {
                var imagetest = await _context.ImageTest.ToListAsync();
                return imagetest;
            }
        }
    }
}