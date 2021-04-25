using Smoos.Domain.Albums;
using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Songs
{
    public class Song : Work, IEntityType<Guid>
    {
        public Song(Guid id, string name, string releaseYear,string duration, Guid artistId): base(id, name, releaseYear)
        {
            Duration = duration;
            ArtistId = artistId;
        }

        public Artist Author { get; set; }
        public string Duration { get; set; }
        public Album Album { get; set; }
        public Guid ArtistId { get; set; }
    }
}