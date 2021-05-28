using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Users;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings
{
    public class Rating : IEntityType<Guid>
    {
        public Rating(string comment, int stars,Guid userId, Guid? movieId = null, Guid? bookId = null, Guid? songId = null, Guid? albumId = null)
        {
            Id = Guid.NewGuid();
            Comment = comment;
            Stars = stars;
            User = user;
            UserId = userId;
            MovieId = movieId;
            BookId = bookId;
            SongId = songId;
            AlbumId = albumId;
        }

        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? BookId { get; set; }
        public Guid? SongId { get; set; }
        public Guid? AlbumId { get; set; }
    }
}