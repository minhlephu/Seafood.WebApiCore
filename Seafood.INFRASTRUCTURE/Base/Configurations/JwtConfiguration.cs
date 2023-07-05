using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Seafood.ARCHITECTURE.Constants;
using Seafood.INFRASTRUCTURE.Base.Interfaces;
using Seafood.INFRASTRUCTURE.Base.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Seafood.INFRASTRUCTURE.Base.Configurations
{
    public static class JwtConfiguration
    {
        public static void AddJwtConfig(this IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(ArchitectureContants.KEY_SECRET);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    RequireSignedTokens = true,
                    ValidateIssuer = false,
                    //ValidIssuer = issuer,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
    public class JwtService : IJwtService
    {
        public string CreateToken(JwtModel jwtModel)
        {
            var key = Encoding.ASCII.GetBytes(ArchitectureContants.KEY_SECRET);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                        new Claim(nameof(jwtModel.Id), jwtModel.Id.ToString()),
                        new Claim(nameof(jwtModel.Username), jwtModel.Username),
                        new Claim(nameof(jwtModel.Role), jwtModel.Role),
                    }),
                Expires = DateTime.UtcNow.AddDays(ArchitectureContants.VERIFY_TOKEN_EXPIRE_DAY),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
