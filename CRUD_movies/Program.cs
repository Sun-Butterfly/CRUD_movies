using System.Text.Json.Serialization;
using CRUD_movies;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen(x => x.SwaggerDoc("v1", new OpenApiInfo()
{
    Title = "CRUD_movies",
    Description = "CRUD movies example",
    Version = "1.0"
}));
builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();