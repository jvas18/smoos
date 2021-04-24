using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Smoos.Domain.Common._Config;
using Smoos.Domain.Common.Pipelines;
using Smoos.Domain.Users.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Smoos.Api._Config
{
    public static class MediatorConfig
    {
        public static IServiceCollection AppAddMediator(this IServiceCollection services)
        {
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));
            services.AddMediatR(typeof(CreateUser).GetTypeInfo().Assembly);

            return services;
        }
    }
}
