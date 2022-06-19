using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace FunctionApp;

public class FunctionUsingIConfiguration
{
    private readonly Configuration _configuration;

    public FunctionUsingIConfiguration(IConfiguration configuration)
    {
        _configuration = configuration.Get<Configuration>();
    }

    [FunctionName(nameof(GetLocalTimeOriginal))]
    public ActionResult GetLocalTimeOriginal([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = $"{nameof(FunctionUsingIConfiguration)}/localtime")] HttpRequest request)
    {
        return new OkObjectResult($"{_configuration.Header}: {DateTime.Now}");
    }

    private class Configuration
    {
        public string Header { get; init; }
    }
}