using FoodGenerateAPI.Db;
using FoodGenerateAPI.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodGenerateAPI.Commands.Create
{
    public class CreateFoodCommand : IRequest<int>
    {
        public string FoodName { get; set; }
        public string ImageData { get; set; }
        //public int MyProperty { get; set; }
        public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, int>
        {
            private readonly AppDbContext _context;
            public CreateFoodCommandHandler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateFoodCommand command, CancellationToken cancellationToken)
            {
                var food = new Food();
                food.FoodName = command.FoodName;
                food.ImageData = command.ImageData;
                _context.Foods.Add(food);
                await _context.SaveChangesAsync();
                return food.Id;
            }
        }
    }
    
}
