using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Songs;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Albums
{
    public class Album : Work, IEntityType<Guid>
    {
        public Artist Singer { get; set; }
        public string Duration { get; set; }
        public Guid ArtistId { get; set; }
        public ICollection<Song> Songs = new List<Song>();

        public Album(Guid id, string name, string releaseYear,string duration, Guid artistId): base(id, name, releaseYear)
        {
            Duration = duration;
            ArtistId = artistId;
        }
    }
}