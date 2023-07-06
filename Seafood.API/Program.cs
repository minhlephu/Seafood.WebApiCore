using Microsoft.EntityFrameworkCore;
using Seafood.INFRASTRUCTURE;
using Seafood.ARCHITECTURE.Entities.Models;
using Seafood.CORE;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using Seafood.INFRASTRUCTURE.Base.Configurations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.HttpsPolicy;
using Seafood.API.Middlewares;

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
    option => option.MigrationsAssembly("Seafood.ARCHITECTURE")));

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
#region 3864 my config
// Middleware
app.UseMiddleware<FirstMiddleware>();
//app.UseMiddleware<LoggingMiddleware>();
//app.UseMiddleware<AuthenticationMiddleware>();
//app.UseMiddleware<RoutingMiddleware>();
//app.UseMiddleware<ExceptionHandlingMiddleware>();
//app.UseMiddleware<CorsMiddleware>();
//app.UseMiddleware<GzipCompressionMiddleware>();
//app.UseMiddleware<HttpsRedirectionMiddleware>();

app.UseAuthentication();

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
