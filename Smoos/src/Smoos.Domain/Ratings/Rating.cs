using Smoos.Domain.Albums;
using Smoos.Domain.Artists;
using Smoos.Domain.Books;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Movies;
using Smoos.Domain.Songs;
using Smoos.Domain.Users;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings
{
    public class Rating : IEntityType<Guid>
    {
        public Rating(string comment, int stars,Guid userId, string title, Guid? movieId = null, Guid? bookId = null, Guid? songId = null, Guid? albumId = null)
        {
            Id = Guid.NewGuid();
            Comment = comment;
            Stars = stars;
            UserId = userId;
            MovieId = movieId;
            BookId = bookId;
            Title = title;
            SongId = songId;
            CreatedAt = DateTime.Now;
            AlbumId = albumId;
        }

        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Movie Movie { get; set; }
        public Song Song { get; set; }
        public Book Book { get; set; }
        public Album Album { get; set; }
        public Guid UserId { get; set; }
        public Guid? MovieId { get; set; }
        public Guid? BookId { get; set; }
        public Guid? SongId { get; set; }
        public Guid? AlbumId { get; set; }
    }
}