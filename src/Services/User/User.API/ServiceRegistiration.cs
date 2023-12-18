using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using User.API.Context;
using User.API.SecurityToken;
using User.API.Services;

namespace User.API
{
    public static class ServiceRegistiration
    {
        public static IServiceCollection UserServiceRegistiration(this IServiceCollection services, IConfiguration configuration)
        {
            // Add framework services.
            services.AddDbContext<QuotaUserDbContext>(options =>
                options.UseNpgsql(configuration.GetValue<string>("DatabaseSettings:ConnectionString")));

            services.AddIdentity<Entities.User, Entities.Role>().AddEntityFrameworkStores<QuotaUserDbContext>().AddDefaultTokenProviders();


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Admin", options =>
                {
                    options.TokenValidationParameters = new()
                    {
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,

                        ValidAudience = configuration["Token:Audience"],
                        ValidIssuer = configuration["Token:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:SecurityKey"]))
                    };
                });
            services.AddScoped<ITokenHandler, SecurityToken.TokenHandler>();

            services.AddAutoMapper(typeof(Program));


            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
