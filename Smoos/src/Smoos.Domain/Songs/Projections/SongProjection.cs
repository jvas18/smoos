using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.Projections;
using Smoos.Domain.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Songs.Projections
{
    public static class SongProjection
    {
        public static IQueryable<SongVm> ToVm(this IQueryable<Song> query) =>
       query.Select(entity => new SongVm
       {
           Id = entity.Id,
           Name = entity.Name,
           ReleaseYear = entity.ReleaseYear,
           Duration = entity.Duration,
           ArtistId = entity.ArtistId,
           AlbumId = entity.AlbumId,
           Poster = entity.Poster,
           Album = entity.Album == null ? null : new AlbumVm
           {
               Id = entity.AlbumId.GetValueOrDefault(),
               Name = entity.Name,
               ArtistId = entity.Album.ArtistId
           },
           Singer = entity.Author == null ? null : new ArtistVm
           {

               Id = entity.ArtistId,
               Photo = entity.Author.Photo,
               Name = entity.Author.Name

           },
           Rate = entity.Rate,
           Ratings = entity.Ratings.ToVm()

       });
        public static IEnumerable<SongVm> ToVm(this IEnumerable<Song> query) => query.AsQueryable().ToVm();
        public static SongVm ToVm(this Song entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
