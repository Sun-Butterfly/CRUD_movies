namespace CRUD_movies;

public class LoggerMiddleware
{
    private readonly RequestDelegate _next;

    public LoggerMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext, ILogger<LoggerMiddleware> logger)
    {
        logger.LogInformation("BEFORE: {path}", httpContext.Request.Path);

        await _next(httpContext);
        
        logger.LogInformation("AFTER: {path}", httpContext.Request.Path);
    }
}