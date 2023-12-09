using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using User.API.Context;

namespace User.API
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection UserServiceRegistiration(this IServiceCollection services, IConfiguration configuration)
        {
            // Add framework services.
            services.AddDbContext<QuotaUserDbContext>(options =>
                options.UseNpgsql(configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

            //services.AddIdentity<Entities.User, Entities.Role<int>>()
            //                .AddEntityFrameworkStores<QuotaUserDbContext, int>()
            //                .AddDefaultTokenProviders();

            services.AddIdentity<Entities.User, Entities.Role>().AddEntityFrameworkStores<QuotaUserDbContext>().AddDefaultTokenProviders();

            return services;
        }
    }
}
