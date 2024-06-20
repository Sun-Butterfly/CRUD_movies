var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();