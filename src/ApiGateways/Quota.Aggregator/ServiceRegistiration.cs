using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Context;
using Quota.Aggregator.Services;

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


            services.AddScoped<IUserQuoteService, UserQuoteService>();

            services.AddHttpClient<IUserQuoteService, UserQuoteService>(c =>
            {
                c.BaseAddress = new Uri(configuration["ApiSettings:QuoteUri"]);
            });


            return services;
        }
    }
}
