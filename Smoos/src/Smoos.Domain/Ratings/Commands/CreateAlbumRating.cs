using MediatR;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings.Commands
{
    public class CreateAlbumRating : IRequest<RatingVm>
    {
        public string Comment { get; set; }
        public string Title { get; set; }
        public int Stars { get; set; }
        public Guid UserId { get; set; }
        public Guid AlbumId { get; set; }
    }
}
