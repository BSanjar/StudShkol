using System.Collections.Generic;
using MediatR;
using Domain;
using System.Threading.Tasks;
using System.Threading;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.ImagesAnswer
{
    public class List
    {
        public class Query : IRequest<List<ImageAnswer>> { }
        public class Handler : IRequestHandler<Query, List<ImageAnswer>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ImageAnswer>> Handle(Query request, CancellationToken cancellationToken)
            {
                var imageAnswer = await _context.ImageAnswer.ToListAsync();
                return imageAnswer;
            }
        }
    }
}