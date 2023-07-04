using Microsoft.EntityFrameworkCore;
using Seafood.INFRASTRUCTURE;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE;
using Seafood.CORE.Base.Interfaces;
using Seafood.CORE.Base.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 3864 my config

// Config Security JWT
builder.Services.AddJwtConfig();

// Set round to LowerCase
builder.Services.AddRouting(
    options =>
    {
        options.LowercaseUrls = true;
    });

// Add DbContext
builder.Services.AddDbContext<SeafoodDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SeafoodConnection"),
    option => option.MigrationsAssembly("ToolApi.CORE")));

// Add DI in Seafood.CORE
builder.Services.AddCoreDI();

// Add DependencyInjection
builder.Services.AddScoped<ISeafoodDbContext, SeafoodDbContext>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
