using System.Collections.Generic;
using FoodGenerateAPI.Models;
using MediatR;

namespace FoodGenerateAPI.Commands
{
    public class AddFoods
    {
        public class Command : IRequest<IEnumerable<Food>>
        {
            public Food Food { get; set; }
        }

    }
}