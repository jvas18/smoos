using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Smoos.Domain.Books
{
    public class Book : Work, IEntityType<Guid>
    {
        public Book(Guid id, string name, string releaseYear,  string pages, string summary, string publisher, Guid artistId): base(id,name,releaseYear)
        {
            Pages = pages;
            Summary = summary;
            Publisher = publisher;
            ArtistId = artistId;
        }

        public Artist Author { get; set; }
        public string Pages { get; set; }
        public string Summary { get; set; }
        public string Publisher { get; set; }
        public Guid ArtistId { get; set; }
    }
}
