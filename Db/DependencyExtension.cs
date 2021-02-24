using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodGenerateAPI.Db
{
    public static class DependencyExtension
    {
        public static void AddInMemoryDatabaseService(this IServiceCollection services, string dbName)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(dbName));
        }

        public static void InitializeSeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var service = serviceScope.ServiceProvider;
                FoodDbSeeder.Seed(service);
            }
        }
    }
}