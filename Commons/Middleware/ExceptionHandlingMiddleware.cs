using App.Wiz.Common.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace App.Wiz.Common.Middleware;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        HttpResponse response = context.Response;

        ErrorResponse errorResponse = new()
        {
            success = false
        };

#pragma warning disable CS8629 // Nullable value type may be null.

        switch (exception)
        {
            case ApplicationException ex:
                HandleApplicationException(response, errorResponse, ex);
                break;
            case DbUpdateException dbEx when dbEx?.InnerException is SqlException sqlEx && sqlEx.Number == 2601:
                HandleDuplicateRecordException(response, errorResponse, dbEx);
                break;
            case DbUpdateException dbEx when (bool)(dbEx?.InnerException?.Message.Contains("UNIQUE KEY")):
                HandleDuplicateRecordException(response, errorResponse, dbEx);
                break;
            case DbUpdateException dbEx when dbEx.InnerException is SqlException sqlEx && (sqlEx.Number == 547 || sqlEx.Number == 5471):
                HandleForeignKeyConstraintException(response, errorResponse, dbEx);
                break;
            default:
                HandleInternalServerError(response, errorResponse, exception);
                break;
        }

#pragma warning restore CS8629 // Nullable value type may be null.

        string result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }

    private void HandleApplicationException(HttpResponse response, ErrorResponse errorResponse, ApplicationException ex)
    {
        if (ex.Message.Contains("Invalid Token"))
        {
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            errorResponse.message = ex.Message;
        }
        else
        {
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            errorResponse.message = ex.Message;
        }
    }

    private void HandleDuplicateRecordException(HttpResponse response, ErrorResponse errorResponse, DbUpdateException dbEx)
    {
        response.StatusCode = (int)HttpStatusCode.BadRequest;
        errorResponse.message = Constants.AlreadyExist;  //dbEx?.InnerException?.Message;// "Already Exist!";
        errorResponse.innerMessge = dbEx?.InnerException?.Message;
        _logger.LogError(dbEx, "Duplicate record found");
    }

    private void HandleForeignKeyConstraintException(HttpResponse response, ErrorResponse errorResponse, DbUpdateException dbEx)
    {
        response.StatusCode = (int)HttpStatusCode.BadRequest;
        errorResponse.message = Constants.CanNotDeleteParent;
        errorResponse.innerMessge = dbEx?.InnerException?.Message;
        _logger.LogError(dbEx, "Foreign key constraint violation");
    }

    private void HandleInternalServerError(HttpResponse response, ErrorResponse errorResponse, Exception exception)
    {
        response.StatusCode = (int)HttpStatusCode.InternalServerError;
        errorResponse.message = exception.Message;
        _logger.LogError(exception.Message);
    }
}

internal class ErrorResponse
{
    public bool success { get; set; }
    public string? message { get; set; }
    public string? innerMessge { get; set; } = string.Empty;
}

