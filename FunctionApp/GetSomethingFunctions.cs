using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace FunctionApp;

public class GetSomethingFunctions
{
    private readonly Configuration _configuration;

    public GetSomethingFunctions(Configuration configuration)
    {
        _configuration = configuration;
    }

    [FunctionName(nameof(GetLocalTime))]
    public ActionResult GetLocalTime([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "localtime")] HttpRequest request)
    {
        return new OkObjectResult($"{_configuration.Header}: {DateTime.Now}");
    }

    public class Configuration
    {
        public string Header { get; set; }
    }
}