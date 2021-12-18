using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lemka.UIL.Infrastructure;

public class ApiExceptionFilter : ExceptionFilterAttribute
{
    private readonly ILogger _logger;

    public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
    {
        _logger = logger;
    }

    public override void OnException(ExceptionContext context)
    {
        ApiErrorModel? apiError = null;
        if (context.Exception is UnauthorizedAccessException)
        {
            apiError = new ApiErrorModel("Unauthorized Access");
            context.HttpContext.Response.StatusCode = 401;
            _logger.LogError("Unauthorized Access");
        }
        else
        {
#if DEBUG
            string msg = context.Exception.GetBaseException().Message;
            string stack = context.Exception.StackTrace;
#else
            string msg = "An unhandled error occurred.";
            string stack = null;
#endif

            apiError = new ApiErrorModel(msg);
            apiError.Detail = stack;
            context.HttpContext.Response.StatusCode = 500;
            // handle logging here
            _logger.LogError(msg);
        }
        // always return a JSON result
        context.Result = new JsonResult(apiError);
        base.OnException(context);
    }
}