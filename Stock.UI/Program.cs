
using Stock.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Stock.Application.Service.Interfaces;
using Stock.Application.Services;
using Stock.Domain.Interfaces;
using Stock.Persistence.Repositories;
using Mapster;
using System.Linq.Expressions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<RepositoryDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        x => x.MigrationsAssembly("Stock.UI"));
    options.EnableSensitiveDataLogging();
});

TypeAdapterConfig.GlobalSettings.Compiler = exp => exp.CompileWithDebugInfo();

builder.Services.AddControllers().AddApplicationPart(typeof(Controller).Assembly);
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
