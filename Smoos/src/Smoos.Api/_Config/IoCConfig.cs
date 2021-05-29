using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Smoos.Data;
using Smoos.Data.Repositories;
using Smoos.Domain.Albums;
using Smoos.Domain.Artists;
using Smoos.Domain.Books;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Security;
using Smoos.Domain.Movies;
using Smoos.Domain.Ratings;
using Smoos.Domain.Songs;
using Smoos.Domain.Suggestions;
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




            services.AddScoped<IJwtService,JwTokenService>();



            services.AddScoped<DbContext,SmoosContext>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IArtistRepository, ArtistRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<ISuggestionRepository, SuggestionRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ISongRepository, SongRepository>();
            return services;
        }
        public static IConfiguration ConfigureEnvVariables<T>(this IConfiguration config,
                            IServiceCollection services)
                            where T : class
        {
            var instance = (T)Activator.CreateInstance(typeof(T));
            if (instance == null) return config;
            config.Bind(instance?.GetType().Name, instance);
            services.AddSingleton(instance);
            return config;
        }
    }
}
