using MediatR;
using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Common;
using Smoos.Domain.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Albums.Commands
{
    public class CreateAlbum : IRequest<AlbumVm>
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public ArtistVm Singer { get; set; }
        public FileInput Poster { get; set; }
        public string Duration { get; set; }
        public Guid? ArtistId { get; set; }
        public ICollection<SongVm> Songs { get; set; }

    }
}
