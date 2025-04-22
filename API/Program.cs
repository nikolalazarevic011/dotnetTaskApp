using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddCors();

var app = builder.Build();

// Configure the HTTP request pipeline. //! Middleware under
app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:4200", "http://localhost:4200"));
app.MapControllers();

app.Run();
