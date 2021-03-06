using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Movies.ViewModels
{
    public class MovieVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Duration { get;  set; }
        public string Poster { get; set; }
        public IEnumerable<ArtistVm> Actors { get; set; }
        public string Summary { get; set; }
        public decimal Rate { get; set; }
        public string Country { get; set; }
        public IEnumerable<RatingVm> Ratings { get; set; }
        public EMovieGenre MovieGenres { get; set; }
    }
}
