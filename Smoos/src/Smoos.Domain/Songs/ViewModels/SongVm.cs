using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Songs.ViewModels
{
    public class SongVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Rate { get; set; }
        public ICollection<RatingVm> Ratings { get; set; }
        public ArtistVm Singer { get; set; }
        public string Duration { get; set; }
        public AlbumVm Album { get; set; }
        public Guid AlbumId { get; set; }
        public Guid ArtistId { get; set; }
    }
}
