using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodGenerateAPI.Db;
using FoodGenerateAPI.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodGenerateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<Food>> GetFoods()
        {
            return await _mediator.Send(new Queries.GetFoodQuery.Query());
        }

        [HttpGet("random")]
        public async Task<IEnumerable<Food>> GetRandomFood()
        {
            return await _mediator.Send(new Queries.GetRandomFoodQuery.Query());
        }
    }
}