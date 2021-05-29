using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Books.ViewModels
{
    public class BookVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Poster { get; set; }
        public ArtistVm Author { get; set; }
        public string Pages { get; set; }
        public string Summary { get; set; }
        public string Publisher { get; set; }
        public decimal Rate { get; set; }
        public IEnumerable<RatingVm> Ratings{ get; set; }
        public Guid ArtistId { get; set; }
    }
}
