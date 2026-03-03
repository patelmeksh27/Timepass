public class MyCustomMiddleware
{
    private readonly RequestDelegate _next;

    public MyCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        await context.Response.WriteAsync("Before Middleware\n");

        await _next(context);

        await context.Response.WriteAsync("\nAfter Middleware");
    }
}