var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IMessageService, MessageService>();

var app = builder.Build();

app.MapGet("/", (IMessageService service) =>
{
    return service.GetMessage();
});

app.Run();