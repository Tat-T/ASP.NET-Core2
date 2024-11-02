using CocktailApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IOutputService, FileOutputService>();
builder.Services.AddScoped<ICSer, JsonCSer>();
builder.Services.AddScoped<ICSer, XmlCSer>();

var app = builder.Build();

app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();
app.Run();