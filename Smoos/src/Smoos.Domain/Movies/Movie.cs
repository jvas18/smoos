using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Movies
{
    public class Movie : Work, IEntityType<Guid>
    {
        public Movie(Guid id, string name, string releaseYear, string duration, string summary, string country, EMovieGenre movieGenres) : base(id, name, releaseYear)
        {
            Duration = duration;
            Summary = summary;
            Country = country;
            MovieGenres = movieGenres;
        }
        public string Duration { get; private set; }

        public ICollection<Artist> Actors = new List<Artist>();

        public string Summary { get; set; }
        public string Country { get; set; }
        public EMovieGenre MovieGenres { get; set; }
    }       
}
