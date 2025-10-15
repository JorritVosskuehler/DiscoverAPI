using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<AuthService>();

var app = builder.Build();

app.MapControllers();

app.Run();