using Jwks.Manager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Security.JwtExtensions;
using Smoos.Data;
using Smoos.Domain.Common._Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api._Config
{
    public static class AuthenticationConfig
    {
        public static IServiceCollection AppAddAuthorization(this IServiceCollection services,
             IConfiguration config, IWebHostEnvironment env)
        {
            var jwTokenConfig = new JwTokenConfig();
            config.GetSection(nameof(JwTokenConfig)).Bind(jwTokenConfig);

            var appConfig = new AppConfig();
            config.GetSection(nameof(AppConfig)).Bind(appConfig);

            services.AddJwksManager(o =>
            {
                o.Algorithm = Algorithm.RS256;
            })
                .PersistKeysToDatabaseStore<SmoosContext>();

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = appConfig.RequireHttps;
                x.SaveToken = true;
                x.SetJwksOptions(new JwkOptions($"{appConfig.BaseUrl}/jwks"));
            });

            services.AddAuthorization(auth =>
            {
                //auth.AddPolicy(AppPolices.BackofficeAdmin, policy =>
                //{
                //    policy.RequireAuthenticatedUser()
                //        .RequireClaim(CustomClaims.Profile, EUserProfile.Admin.ToString())
                //        .Build();
                //});

                //auth.AddPolicy(AppPolices.BackofficeOperator, policy =>
                //{
                //    policy.RequireAuthenticatedUser()
                //        .RequireClaim(CustomClaims.Profile, EUserProfile.Admin.ToString(), EUserProfile.Operator.ToString())
                //        .Build();
                //});

                //auth.AddPolicy(AppPolices.Industry, policy =>
                //{
                //    policy.RequireAuthenticatedUser()
                //        .RequireClaim(CustomClaims.Profile, EUserProfile.Industry.ToString())
                //        .Build();
                //});

                //auth.AddPolicy(AppPolices.Customer, policy =>
                //{
                //    policy.RequireAuthenticatedUser()
                //        .RequireClaim(CustomClaims.Profile, EUserProfile.Customer.ToString())
                //        .Build();
                //});
            });

            return services;
        }


    }
}

