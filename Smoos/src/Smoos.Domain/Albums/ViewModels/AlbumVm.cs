using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.ViewModels;
using Smoos.Domain.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Albums.ViewModels
{
    public class AlbumVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Rate { get; set; }
        public IEnumerable<RatingVm> Ratings { get; set; }
        public ArtistVm Singer { get; set; }
        public string Poster { get; set; }
        public string Duration { get; set; }
        public Guid ArtistId { get; set; }
        public ICollection<SongVm> Songs = new List<SongVm>();
    }
}
