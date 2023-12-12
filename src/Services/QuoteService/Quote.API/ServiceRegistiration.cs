using Microsoft.EntityFrameworkCore;
using Quote.API.Context;
using Quote.API.Repositories;
using Quote.API.Services;

namespace Quote.API
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection QuoteServiceRegistiration(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<QuotaQuoteDbContext>(options =>
            {
                options.UseNpgsql(config["DatabaseSettings:ConnectionString"]);
            });

            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteService, QuoteService>();

            return services;
        }
    }
}
