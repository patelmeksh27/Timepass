var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<MyCustomMiddleware>();

// app.MapGet("/", () => "Inside Endpoint");
app.Run(async context =>
{
    await context.Response.WriteAsync("Final Endpoint Executed\n");
});

app.Run();