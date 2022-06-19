using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace FunctionApp;

public class FunctionUsingPoco
{
    private readonly Configuration _configuration;

    public FunctionUsingPoco(Configuration configuration)
    {
        _configuration = configuration;
    }

    [FunctionName(nameof(AltGetLocalTime))]
    public ActionResult AltGetLocalTime([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = $"{nameof(FunctionUsingPoco)}/localtime")] HttpRequest request)
    {
        return new OkObjectResult($"{_configuration.Header}: {DateTime.Now}");
    }

    public class Configuration
    {
        public string Header { get; init; }
    }
}