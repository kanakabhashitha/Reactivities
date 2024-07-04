using Application.Core;
using Domain.obj;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>>{}

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;


            public Handler(DataContext context)
            {
                _context = context;
               
            }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {
                // try
                // {
                //     for(var i = 0; i < 10; i++)
                //     {
                //         cancellationToken.ThrowIfCancellationRequested();
                //         await Task.Delay(1000, cancellationToken);
                //         _logger.LogInformation($"Task {i} completed");
                //     }
                // }
                // catch (System.Exception)
                // {
                //     _logger.LogInformation("Task was cancelled");
                // }
                
                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync());
            }
        }
    }
}