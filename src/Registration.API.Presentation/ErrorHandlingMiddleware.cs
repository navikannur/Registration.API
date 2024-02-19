using FastEndpoints;
using FluentValidation;

namespace Registration.API.Presentation;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var code = StatusCodes.Status500InternalServerError;

        var errorResponse = new ErrorResponse
        {
            StatusCode = code
        };

        if (exception is ValidationException validationException)
        {
            code = StatusCodes.Status400BadRequest;
            errorResponse.Errors = (Dictionary<string, List<string>>)validationException.Errors;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = code;

        await context.Response.WriteAsJsonAsync(errorResponse);
    }
}
