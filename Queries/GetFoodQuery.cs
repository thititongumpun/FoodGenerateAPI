using FoodGenerateAPI.Db;
using FoodGenerateAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodGenerateAPI.Queries
{
    public class GetFoodQuery
    {
        public class Query : IRequest<IEnumerable<Food>> { }
        public class Handler : IRequestHandler<Query, IEnumerable<Food>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Food>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Foods.OrderByDescending(f => f.Review).ToListAsync();
            }
        }
    }
}
