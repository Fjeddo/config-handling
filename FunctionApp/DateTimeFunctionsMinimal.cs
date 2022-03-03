using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp;

public record DateTimeFunctionsMinimal(ILogger<DateTimeFunctionsLogDecorated> Logger)
{
    [FunctionName(nameof(JulaftonDayOfWeek))]
    public IActionResult JulaftonDayOfWeek([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "julafton/{year}")] HttpRequest request, int year)
    {
        Logger.LogInformation("Minimal functions - JulaftonDayOfWeek invoked");
        return new OkObjectResult(DateOnly.Parse($"{year}-12-24").ToString("dddd"));
    }
}