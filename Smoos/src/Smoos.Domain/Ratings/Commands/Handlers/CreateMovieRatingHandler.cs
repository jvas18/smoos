using MediatR;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Movies;
using Smoos.Domain.Ratings.Projections;
using Smoos.Domain.Ratings.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Ratings.Commands.Handlers
{
    public class CreateMovieRatingHandler : IRequestHandler<CreateMovieRating, RatingVm>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IMovieRepository _movieRepository;

        public CreateMovieRatingHandler(IRatingRepository ratingRepository, IMovieRepository movieRepository)
        {
            _ratingRepository = ratingRepository;
            _movieRepository = movieRepository;
        }

        public async Task<RatingVm> Handle(CreateMovieRating request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.AddAsync(new Rating(request.Comment, request.Stars, request.UserId,request.Title, request.MovieId));

            return rating.ToVm();
        }
    }
}
