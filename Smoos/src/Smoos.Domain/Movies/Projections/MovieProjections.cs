using Smoos.Domain.Artists.Projections;
using Smoos.Domain.Movies.ViewModels;
using Smoos.Domain.Ratings.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Movies.Projections
{
    public static class MovieProjections
    {
        public static IQueryable<MovieVm> ToVm(this IQueryable<Movie> query) =>
        query.Select(entity => new MovieVm
        {
            Id = entity.Id,
            Name = entity.Name,
            ReleaseYear = entity.ReleaseYear,
            Summary = entity.Summary,
            Country = entity.Country,
            Duration = entity.Duration,
            Rate = entity.Rate,
            Poster = entity.Poster,
            MovieGenres = entity.MovieGenres,
            Actors = entity.Actors.ToVm(),
            Ratings = entity.Ratings.ToVm()

        });

        public static IEnumerable<MovieVm> ToVm(this IEnumerable<Movie> query) => query.AsQueryable().ToVm();
        public static MovieVm ToVm(this Movie entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
