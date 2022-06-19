using FunctionApp;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

[assembly:FunctionsStartup(typeof(Startup))]

namespace FunctionApp;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddConfiguration<FunctionUsingPoco.Configuration>();
        builder.Services.AddIOptionsConfiguration<FunctionUsingIOptions.MyConfigs>();
    }

    public override void ConfigureAppConfiguration(IFunctionsConfigurationBuilder builder)
    {
        base.ConfigureAppConfiguration(builder);
        builder.ConfigurationBuilder.AddJsonFile(builder.GetContext().ApplicationRootPath + "\\appsettings.json").Build();
    }
}