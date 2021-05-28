﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Ratings.Projections;
using Smoos.Domain.Ratings.ViewModels;
using Smoos.Domain.Songs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Ratings.Commands.Handlers
{
    public class CreateSongRatingHandler : IRequestHandler<CreateSongRating, RatingVm>
    {
        private readonly IRatingRepository _ratingRepository;
        private readonly ISongRepository _songRepository;

        public CreateSongRatingHandler(IRatingRepository ratingRepository, ISongRepository songRepository)
        {
            _ratingRepository = ratingRepository;
            _songRepository = songRepository;
        }

        public async Task<RatingVm> Handle(CreateSongRating request, CancellationToken cancellationToken)
        {
            var rating = await _ratingRepository.AddAsync(new Rating(request.Comment, request.Stars, request.UserId, null, null, request.SongId));
            var song = await _songRepository.ListAsNoTracking().FirstOrDefaultAsync(x => x.Id == request.SongId);
            int media = 0;
            foreach (var r in song.Ratings)
            {
                media += r.Stars;
            }
            media = media / song.Ratings.Count();
            song.Rate = media;
            _songRepository.Modify(song);

            return rating.ToVm();
        }
    }
}
