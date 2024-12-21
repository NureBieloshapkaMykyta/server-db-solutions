using Application.Abstractions;
using Application.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class RegisterLayerExtension
{
    public static void AddApplication(this IServiceCollection services) 
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
