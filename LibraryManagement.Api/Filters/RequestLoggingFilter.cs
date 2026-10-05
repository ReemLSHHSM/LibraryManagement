using Microsoft.AspNetCore.Mvc.Filters;

namespace LibraryManagement.Api.Filters
{
  public class RequestLoggingFilter : ActionFilterAttribute
  {
    private readonly ILogger<RequestLoggingFilter> _logger;

    public RequestLoggingFilter(ILogger<RequestLoggingFilter> logger)
    {
      _logger = logger;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      _logger.LogInformation($"Request: {context.HttpContext.Request.Method} {context.HttpContext.Request.Path}");
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
      _logger.LogInformation($"Response: {context.HttpContext.Response.StatusCode}");
    }
  }
}
