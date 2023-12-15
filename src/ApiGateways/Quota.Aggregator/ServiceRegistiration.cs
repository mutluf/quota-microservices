using EventBus.Messages.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Quota.Aggregator.Consumers;
using Quota.Aggregator.Context;
using Quota.Aggregator.Repositories;
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

            services.AddAutoMapper(typeof(Program));

            services.AddScoped<IUserQuoteService, UserQuoteService>();
            services.AddScoped<IUserQuoteRepository, UserQuoteRepository>();

            services.AddHttpClient<IUserQuoteService, UserQuoteService>(c =>
            {
                c.BaseAddress = new Uri(configuration["ApiSettings:QuoteUri"]);
            });



            services.AddMassTransit(config =>
            {
                config.AddConsumer<QuoteCreatedConsumer>();

                config.UsingRabbitMq((context, configurator) =>
                {
                    configurator.Host(configuration["EventBusSettings:HostAddress"]);

                    configurator.ReceiveEndpoint(EventBusConstants.QuoteCreatedQueue, c => c.ConfigureConsumer<QuoteCreatedConsumer>(context));
                });
            });


            return services;
        }
    }
}
