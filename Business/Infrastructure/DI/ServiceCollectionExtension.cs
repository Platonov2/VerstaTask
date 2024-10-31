using Business.Infrastructure.Automapper;
using Business.Services.Order;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Infrastructure.DI;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddBusiness(this IServiceCollection services)
    {
        services.AddTransient<IOrderService, OrderService>();

        services.AddAutoMapper(typeof(OrderMappingProfile));

        return services;
    }
}
