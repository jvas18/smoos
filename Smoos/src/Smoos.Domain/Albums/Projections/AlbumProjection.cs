using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Artists.ViewModels;
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
           ReleaseYear = entity.ReleaseYear,
           Duration = entity.Duration,
           ArtistId = entity.ArtistId,
           Rate = entity.Rate,
           Singer = entity.Singer == null? null : new ArtistVm
           {
               Id = entity.ArtistId,
               Name = entity.Singer.Name
           }


       });

        public static IEnumerable<AlbumVm> ToVm(this IEnumerable<Album> query) => query.AsQueryable().ToVm();
        public static AlbumVm ToVm(this Album entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
