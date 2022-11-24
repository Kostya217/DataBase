using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UserManager.Data.Model;
using UserManager.Data.Repository;
using UserManager.Service;

namespace UserManager.Data
{
    public static class DiExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAccessRoleRepository, AccessRoleRepository>();
            services.AddScoped<IAccessRuleRepository, AccessRuleRepository>();

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("MySqlDatabase"),
                                 ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlDatabase")))
            );

            return services;
        }

        public static IServiceCollection AddService(
            this IServiceCollection services)
        {

            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAccessRoleService, AccessRoleService>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
