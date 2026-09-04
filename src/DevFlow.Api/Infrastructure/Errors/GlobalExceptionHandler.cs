using DevFlow.Domain.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DevFlow.Api.Infrastructure.Errors;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(
        ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(
            exception,
            "An unhandled exception occurred.");

        var statusCode = exception switch
        {
            DomainException =>
                StatusCodes.Status400BadRequest,

            _ =>
                StatusCodes.Status500InternalServerError
        };

        var title = exception switch
        {
            DomainException =>
                "The request could not be processed.",

            _ =>
                "An unexpected error occurred."
        };

        var detail = exception is DomainException
            ? exception.Message
            : "An unexpected error occurred.";

        var problemDetails = new ProblemDetails
        {
            Status = statusCode,
            Title = title,
            Detail = detail
        };

        httpContext.Response.StatusCode = statusCode;

        await httpContext.Response.WriteAsJsonAsync(
            problemDetails,
            cancellationToken);

        return true;
    }
}