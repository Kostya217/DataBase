using Microsoft.EntityFrameworkCore;

namespace UserManager.Data
{
    public static class DiExtensions
    {
        public static IServiceCollection AddData(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<ApplicationDbContext>();

            services.AddDbContextPool<ApplicationDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("MySqlDatabase"),
                                 ServerVersion.AutoDetect(configuration.GetConnectionString("MySqlDatabase")))
            );

            return services;
        }
    }
}
