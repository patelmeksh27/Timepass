var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// First Middleware
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("First Middleware Start\n");

    await next();   // Call second middleware

    await Task.Delay(3000);   // 2 second delay AFTER second middleware

    await context.Response.WriteAsync("First Middleware End\n");
});

// Second Middleware
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Second Middleware Executed\n");

    await next();
});

// Endpoint
app.MapGet("/", () => "Endpoint Executed\n");

app.Run();