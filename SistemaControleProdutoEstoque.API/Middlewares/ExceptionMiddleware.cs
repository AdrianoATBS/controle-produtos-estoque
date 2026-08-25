using Microsoft.AspNetCore.Http.HttpResults;
using SistemaControleProdutoEstoque.API.Responses;
using SistemaControleProdutosEstoque.Application.Exceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace SistemaControleProdutoEstoque.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, 
        ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode;

        switch(exception)
        {
            case NotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                break;
            case ValidationException:
                statusCode = StatusCodes.Status400BadRequest;
                break;
            case BusinessException:
                statusCode = StatusCodes.Status409Conflict;
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                break;
        }

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var response = new ErrorResponse
        {
           StatusCode = statusCode,
           Message = exception.Message,
           Details = _env.IsDevelopment() ? exception.StackTrace : null
        };
        var options = new JsonSerializerOptions { 
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase 
        };
        var json = JsonSerializer.Serialize(response, options);

        await context.Response.WriteAsync(json);
    }
}
