var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// First Middleware
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("First Middleware Start\n");

    await next();

    await Task.Delay(2000);   // 2 second delay

    await context.Response.WriteAsync("First Middleware End\n");
});

// Second Middleware
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Second Middleware Executed\n");

    await next();
});

// Final endpoint (Safe)
app.Run(async context =>
{
    await context.Response.WriteAsync("Final Endpoint Executed\n");
});

app.Run();