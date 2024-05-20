using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WAD.CW1._00013292.DAL.Interfaces;
using WAD.CW1._00013292.Data;
using WAD.CW1._00013292.Repositories;

namespace WAD.CW1._00013292.DAL
{
    public static class ConfigurationServices
    {
        public static IServiceCollection DalConfiguration(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IKeyItemRepository, KeyItemRepository>();
            services.AddScoped<IKeyTypeRepository, KeyTypeRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
