using Microsoft.EntityFrameworkCore;
using Quote.API.Context;

namespace Quote.API
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection QuoteServiceRegistiration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<QuotaQuoteDb>(options =>
            {
                options.UseNpgsql(config["DatabaseSettings:ConnectionString"]);
            });

            return services;
        }
    }
}
