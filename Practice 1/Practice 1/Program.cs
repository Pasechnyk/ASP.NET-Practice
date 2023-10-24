using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
string connStr = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<CinemaDbContext>(opts => opts.UseSqlServer(connStr));

builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
