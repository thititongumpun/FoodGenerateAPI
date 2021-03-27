using FoodGenerateAPI.Db;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodGenerateAPI.Commands.Update
{
    public class UpdateFoodCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int Liked { get; set; }

        public class Handler : IRequestHandler<UpdateFoodCommand, int>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateFoodCommand command, CancellationToken cancellationToken)
            {
                var food = _context.Foods.Where(f => f.Id == command.Id).FirstOrDefault();

                if (food == null)
                {
                    return default;
                }
                else
                {
                    food.Liked = command.Liked;
                    await _context.SaveChangesAsync();
                    return food.Id;
                }
            }
        }
    }
}
