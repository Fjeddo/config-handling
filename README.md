# Background
This is a tiny example how to use the .NET built in dependency injection, making handling of configuration settings in the code base really clean and easy to work with. The example is implemented in an Azure function, returning the localtime where ever the func is running.

The configuration settings look like this:
```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "Header": "Local time is"
  }
}
```

# The 'old way'
The most common way to make configuration settings available in a class is to, when using the .NET DI, inject an instance of the IConfiguration interface. Have a look in the [FunctionApp/OriginalTimeFunctions.cs](FunctionApp/OriginalTimeFunctions.cs):
```csharp
public class OriginalTimeFunctions
{
  private readonly Configuration _configuration;

  public OriginalTimeFunctions(IConfiguration configuration)
  {
      _configuration = configuration.Get<Configuration>();
  }
  
  ...
  
  private class Configuration
  {
      public string Header { get; init; }
  }
}
```

The injected instance of IConfguration is used to create an instance of the private nested class `Configuration`. 
Injection of an instance of IConfiguration comes default, out of the box, when using the DI in .NET.

# The 'streamlined way'
In this tiny example it may look a litte bit over the top to handle the configuration in any other way, but as the solution grows and there are hundreds of classes, many of which depends on some configuration settings, one might think that there has to be a better way to handle this.
In the [FunctionApp/OriginalTimeFunctions.cs](FunctionApp/AlternativeTimeFunctions.cs) the injection of IConfiguration is replaced by injection of an instance of the nested Configuration class:
```csharp
public class AlternativeTimeFunctions
{
    private readonly Configuration _configuration;

    public AlternativeTimeFunctions(Configuration configuration)
    {
        _configuration = configuration;
    }
    
    ...
    
    public class Configuration
    {
        public string Header { get; init; }
    }
}
```

To make this injection possible there is an extension of IServiceCollection implemented in [FunctionApp/ConfigurationRegistrations.cs](FunctionApp/ConfigurationRegistrations.cs):
```csharp
public static IServiceCollection AddConfiguration<T>(this IServiceCollection services) where T : class =>
    services.AddSingleton(provider => provider.GetService<IConfiguration>().Get<T>());
```
This extension is used in the [FunctionApp/Startup.cs](FunctionApp/Startup.cs):
```csharp
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services
            .AddConfiguration<AlternativeTimeFunctions.Configuration>();
    }
}
```
In this way all configurations are possible to register and it is possible to inject in classes that need them.

# Unit test, mocking vs real instance
The streamlined way of handling configuration dependencies comes really handy when implementing unit tests for classes.
TBD.
