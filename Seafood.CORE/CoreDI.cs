using Microsoft.Extensions.DependencyInjection;
using Seafood.CORE.AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Seafood.CORE.Base.Interfaces;
using Seafood.CORE.Base.Configurations;

namespace Seafood.CORE
{
    public static class CoreDI
    {
        public static void AddCoreDI(this IServiceCollection services)
        {
            // Add MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Add AutoMapper
            services.AddAutoMapper(typeof(MapperProfile).Assembly);

            services.AddSingleton<IJwtService, JwtService>();

            services.AddSingleton<IJwtService, JwtService>();
        }
    }
}
