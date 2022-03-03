using FunctionApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly:FunctionsStartup(typeof(Startup))]

namespace FunctionApp;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services
            .AddConfiguration<GetSomethingFunctions.Configuration>()
            .AddLogging();
    }
}

public static class ConfigurationRegistrations
{
    public static IServiceCollection AddConfiguration<T>(this IServiceCollection services) where T : class =>
        services.AddSingleton(provider => provider.GetService<IConfiguration>().Get<T>());
}