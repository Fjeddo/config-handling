using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp;

public record DateTimeFunctionsLogDecorated(ILogger<DateTimeFunctionsLogDecorated> Logger) : LogDecoratedFunction<DateTimeFunctionsLogDecorated>(Logger)
{
    [FunctionName(nameof(GetChristmasDayOfWeek))]
    public IActionResult GetChristmasDayOfWeek([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "christmasday/{year}")] HttpRequest request, int year) => Run(() => new OkObjectResult(DateOnly.Parse($"{year}-12-25").ToString("dddd")));
}