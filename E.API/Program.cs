using E.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration.AddJsonFile("appsettings.json")
    .Build();
 

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(config.GetConnectionString("DefaultConnection")));
var app = builder.Build();



app.MapGet("/", () => "Hello World!");

app.Run();
