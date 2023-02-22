using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Exceptions;
using TodoAppBe.Database;
using TodoAppBe.Services;
using TodoAppBe.Services.Interfaces;

namespace TodoAppBe.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            AddDatabase(services, configuration);
            AddServices(services);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes(configuration.GetSection("Token:Key").Value)),
                        ValidIssuer = configuration.GetSection("Token:Issuer").Value,
                        ValidateIssuer = true,
                        ValidateAudience = false
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicy",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:4200", "http://localhost:4200", "http://localhost:7044")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            return services;
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UsersService>();
        }

        #region Infrastructure

        private static void AddDatabase(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                //options.UseInMemoryDatabase("Visma.Bootcamp.eShop-db");
                options.UseMySql(
                    connectionString,
                    ServerVersion.AutoDetect(connectionString),
                    opts => { opts.MigrationsAssembly("TodoAppBe"); });
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });
        }

        #endregion
    }
}