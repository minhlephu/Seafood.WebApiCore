using Microsoft.Extensions.DependencyInjection;
using Seafood.CORE.AutoMapper;
using System.Reflection;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using Seafood.INFRASTRUCTURE.Base.Configurations;
using Seafood.INFRASTRUCTURE;
using Seafood.CORE.Repositories;
using Seafood.CORE.Repositories.UserRepo;

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

            services.AddScoped<ISeafoodDbContext, SeafoodDbContext>();

            services.AddSingleton<IJwtService, JwtService>();

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
