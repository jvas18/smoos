using Smoos.Domain.Artists.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Artists.Projections
{
    public static class ArtistProjections
    {
        public static IQueryable<ArtistVm> ToVm(this IQueryable<Artist> query) =>
         query.Select(entity => new ArtistVm
         {
             Id = entity.Id,
             Name = entity.Name,
             Photo = entity.Photo,
             Description = entity.Description,
             Age = entity.Age
            

         });

        public static IEnumerable<ArtistVm> ToVm(this IEnumerable<Artist> query) => query.AsQueryable().ToVm();
        public static ArtistVm ToVm(this Artist entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
