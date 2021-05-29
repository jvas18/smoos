using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Albums.Projections
{
    public static class AlbumProjection
    {
        public static IQueryable<AlbumVm> ToVm(this IQueryable<Album> query) =>
       query.Select(entity => new AlbumVm
       {
           Id = entity.Id,
           Name = entity.Name,
           Poster = entity.Poster,
           ReleaseYear = entity.ReleaseYear,
           Duration = entity.Duration,
           ArtistId = entity.ArtistId,
           Rate = entity.Rate,
           Singer = entity.Singer == null? null : new ArtistVm
           {
               Id = entity.ArtistId,
               Photo = entity.Singer.Photo,
               Name = entity.Singer.Name
           },
           Ratings = entity.Ratings.ToVm()


       });

        public static IEnumerable<AlbumVm> ToVm(this IEnumerable<Album> query) => query.AsQueryable().ToVm();
        public static AlbumVm ToVm(this Album entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
