using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BrowserApi.Data;
using BrowserApi.EndPoint;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BrowserApiContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BrowserApiContext") ?? throw new InvalidOperationException("Connection string 'BrowserApiContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapNavegadorWebEndpoints();

app.Run();
