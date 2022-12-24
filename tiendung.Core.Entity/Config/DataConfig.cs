using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tiendung.Core.Entity.Data;

namespace tiendung.Core.Entity.Config
{
    public static class DataConfig
    {
        public static void AddDataConfig(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(config.GetConnectionString("SQLConnection")));
        }
    }
}
