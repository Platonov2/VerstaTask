using Business.Infrastructure.DI;
using FluentValidation;
using Storage.Infrastructure.DI;
using Storage.Infrastructure.Options;
using VerstaTask.Automapper;
using VerstaTask.Validators;

namespace VerstaTask;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var storageOptions = builder
            .Configuration
                .GetRequiredSection(StorageOptions.SectionName)
                .Get<StorageOptions>();
        builder.Services.AddStorage(storageOptions);

        ConfigureServices(builder.Services);

        var app = builder.Build();
        ConfigureApp(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddBusiness();
        services.AddAutoMapper(typeof(ViewMapperProfile));
        services.AddValidatorsFromAssemblyContaining<CreateOrderValidator>();
    }

    private static void ConfigureApp(WebApplication app)
    {
        app.UseRouting();
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Orders}/{action=GetAll}");
    }
}
