using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Options;

namespace FunctionApp;

public class FunctionUsingIOptions
{
    private readonly MyConfigs _configuration;

    public FunctionUsingIOptions(IOptions<MyConfigs> configuration)
    {
        _configuration = configuration.Value;
    }

    [FunctionName(nameof(AnotherAlterantiveGetLocalTime))]
    public ActionResult AnotherAlterantiveGetLocalTime([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = $"{nameof(FunctionUsingIOptions)}/localtime")] HttpRequest request)
    {
        return new OkObjectResult($"{_configuration.Header}: {DateTime.Now}");
    }

    public class MyConfigs
    {
        public string Header { get; init; }

    }
}
