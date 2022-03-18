using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionApp;

public static class ConfigurationRegistrations
{
    public static IServiceCollection AddConfiguration<T>(this IServiceCollection services) where T : class =>
        services.AddSingleton(provider => provider.GetService<IConfiguration>().Get<T>());
}