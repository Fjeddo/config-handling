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
TBD
