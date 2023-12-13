using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Context;

namespace Quota.Aggregator
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection AggregatorServiceRegistiration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AggregatorDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetSection("DatabaseSettings:ConnectionString").Value);
            });
            return services;
        }
    }
}
