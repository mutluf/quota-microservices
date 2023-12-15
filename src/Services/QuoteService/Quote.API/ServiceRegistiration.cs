using MassTransit;
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

            services.AddAutoMapper(typeof(Program));

            services.AddScoped<IQuoteRepository, QuoteRepository>();
            services.AddScoped<IQuoteService, QuoteService>();

            //masstransit
            services.AddMassTransit(busConfigurator =>
            {
                //busConfigurator.AddConsumer<UserEnrolledConsumer>();

                busConfigurator.SetKebabCaseEndpointNameFormatter();
                busConfigurator.UsingRabbitMq((context, busFactoryConfigurator) =>
                {


                    busFactoryConfigurator.Host("amqp://localhost/", hostConfigurator =>
                    {
                        hostConfigurator.Username("guest");
                        hostConfigurator.Password("guest");
                    });

                    //busFactoryConfigurator.ReceiveEndpoint("test1", e =>
                    //{
                    //    //e.Consumer<UserEnrolledConsumer>(context);

                    //});

                });
            });

            return services;
        }
    }
}
