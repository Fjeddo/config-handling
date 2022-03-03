using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FunctionApp;

public abstract record LogDecoratedFunction<T>(ILogger<T> Logger)
{
    protected IActionResult Run(Func<IActionResult> func)
    {
        Logger.LogInformation("Invoking the func");
        var result = func();
        Logger.LogInformation("Invoked the func");

        return result;
    }
}