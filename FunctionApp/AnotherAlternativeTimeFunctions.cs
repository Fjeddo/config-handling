using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Options;

namespace FunctionApp;

public class AnotherAlternativeTimeFunctions
{
    private readonly MyConfigs _configuration;

    public AnotherAlternativeTimeFunctions(IOptions<MyConfigs> configuration)
    {
        _configuration = configuration.Value;
    }

    [FunctionName(nameof(AnotherAlterantiveGetLocalTime))]
    public ActionResult AnotherAlterantiveGetLocalTime([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = $"{nameof(AnotherAlternativeTimeFunctions)}/localtime")] HttpRequest request)
    {
        return new OkObjectResult($"{_configuration.Text}: {DateTime.Now}");
    }

    public class MyConfigs
    {
        public string Text { get; init; }
        public string Title { get; init; }
    }
}
