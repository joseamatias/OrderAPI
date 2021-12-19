using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OrderAPI.Application;
using OrderAPI.Infrastructure;
using OrderAPI.Infrastructure.Context;

namespace OrderAPI.Configuration
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureApplication(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IOrderService), typeof(OrderService));

            return services;
        }

        public static IServiceCollection ConfigureDataBase(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<OrderDbContext>();

                //context.Database.Migrate();

                //context.SeedData();
            }

            return services;
        }       
    }
}
