using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Tera.Application.Common.CustomException;
using Tera.Application.Common.Helpers;
using Tera.Application.Common.Models;

namespace Tera.Application.Common.Middlewares;

public class ErrorHandlerMiddleware(RequestDelegate next , ILogger<ErrorHandlerMiddleware> logger)
{
    public async Task Invoke(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            logger.LogError(message: ex.Message, ex);
            var response = context.Response;
            response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCodeForException(ex);
            await context.Response.WriteAsync(GetErrorException(ex).ToString());
           
        }
    }

    private static ErrorModel GetErrorException(Exception ex)
    {
        return ex switch
        {
            KeyNotFoundException or AppException => new ErrorModel(ex.Message),
            _ => new ErrorModel(ErrorHelper.Messages.InternalError),
        };
    }
    private static int GetStatusCodeForException(Exception ex)
    {
        return ex switch
        {
            KeyNotFoundException => (int)System.Net.HttpStatusCode.NotFound,
            AppException => (int)System.Net.HttpStatusCode.BadRequest,
            _ => (int)System.Net.HttpStatusCode.InternalServerError,
        };
    }
}