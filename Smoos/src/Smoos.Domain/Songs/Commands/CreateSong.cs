using MediatR;
using Smoos.Domain.Common;
using Smoos.Domain.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Songs.Commands
{
    public class CreateSong : IRequest<SongVm>
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Duration { get; set; }
        public Guid? AlbumId { get; set; }
        public FileInput Poster { get; set; }
        public Guid ArtistId { get; set; }
    }
}
