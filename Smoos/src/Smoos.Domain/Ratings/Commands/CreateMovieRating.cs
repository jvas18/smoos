using MediatR;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings.Commands
{
    public class CreateMovieRating : IRequest<RatingVm>
    {
        public string Comment { get; set; }
        public int Stars { get; set; }
        public string Title { get; set; }
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }


    }
}
