using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Books.ViewModels;
using Smoos.Domain.Ratings.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Books.Projections
{
    public static class BookProjections
    {
        public static IQueryable<BookVm> ToVm(this IQueryable<Book> query) =>
        query.Select(entity => new BookVm
        {
            Id = entity.Id,
            Name = entity.Name,
            ReleaseYear = entity.ReleaseYear,
            Summary = entity.Summary,
            ArtistId = entity.ArtistId,
            Pages = entity.Pages,
            Rate= entity.Rate,
            Poster = entity.Poster,
            Author = entity.Author == null ? null : new ArtistVm {

                Id = entity.ArtistId,
                Name = entity.Author.Name

            },
            
            Publisher = entity.Publisher,
            Ratings = entity.Ratings.ToVm()

        });

        public static IEnumerable<BookVm> ToVm(this IEnumerable<Book> query) => query.AsQueryable().ToVm();
        public static BookVm ToVm(this Book entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
