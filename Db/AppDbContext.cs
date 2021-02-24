using FoodGenerateAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodGenerateAPI.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Food> Foods {get;set;}
    }
}