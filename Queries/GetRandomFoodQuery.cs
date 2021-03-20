using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FoodGenerateAPI.Db;
using FoodGenerateAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodGenerateAPI.Queries
{
    public class GetRandomFoodQuery
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
                Random rd = new Random();
                return await _context.Foods.OrderBy(f => rd.Next()).Take(1).ToListAsync();
            }
        }
    }
}
