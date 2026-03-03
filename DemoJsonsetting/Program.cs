var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

var siteName = builder.Configuration["MySettings:SiteName"];

app.MapGet("/", () => $"Welcome to {siteName}");

app.Run();