using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class RegisterLayerExtension
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration) 
    {
        services.AddDbContext<InfrastructureContext>(opt=>opt.UseSqlServer(configuration.GetConnectionString("MasterDatabase")));
    }
}
