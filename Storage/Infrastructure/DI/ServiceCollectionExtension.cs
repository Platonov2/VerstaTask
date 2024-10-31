using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Contexts;
using Storage.Infrastructure.Options;
using Storage.Repositories.Orders;

namespace Storage.Infrastructure.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddStorage(
        this IServiceCollection services, 
        StorageOptions storageOptions)
    {
        services.AddDbContext<StorageContext>(options =>
        {
            options.UseSqlite(storageOptions.RequiredConnectionString);
        });

        services.AddTransient<IOrderRepository, OrderRepository>();

        return services;
    }
}
