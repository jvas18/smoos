using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smoos.Data;
using Smoos.Data.Repositories;
using Smoos.Domain.Artists;
using Smoos.Domain.Books;
using Smoos.Domain.Common.Security;
using Smoos.Domain.Movies;
using Smoos.Domain.Users;
using Smoos.Domain.Users.Commands.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api._Config
{
    public static class IoCConfig
    {
        public static IServiceCollection AppAddIoCServices(this IServiceCollection services, IConfiguration config, IHostEnvironment env)
        {




            //services.AddScoped<JwTokenService>();



            services.AddScoped<DbContext,SmoosContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            return services;
        }

    }
}
