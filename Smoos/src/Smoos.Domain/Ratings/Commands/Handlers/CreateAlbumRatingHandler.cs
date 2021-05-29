using MediatR;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Albums;
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
    public class CreateAlbumRatingHandler : IRequestHandler<CreateAlbumRating, RatingVm>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly IAlbumRepository _albumRepository;

        public CreateAlbumRatingHandler(IRatingRepository ratingRepository, IAlbumRepository albumRepository)
        {
            _ratingRepository = ratingRepository;
            _albumRepository = albumRepository;
        }

        public async Task<RatingVm> Handle(CreateAlbumRating request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.AddAsync(new Rating(request.Comment, request.Stars, request.UserId,request.Title, null, null, null, request.AlbumId));

            return rating.ToVm();
        }
    }
}
