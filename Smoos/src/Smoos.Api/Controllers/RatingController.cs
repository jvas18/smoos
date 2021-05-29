using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Ratings;
using Smoos.Domain.Ratings.Commands;
using Smoos.Domain.Ratings.Projections;
using System;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRatingRepository _ratingRepository;

        public RatingController(IMediator mediator, IRatingRepository ratingRepository)
        {
            _mediator = mediator;
            _ratingRepository = ratingRepository;
        }

        [HttpPost("/movie-rating")]
        public async Task<IActionResult> Post([FromBody] CreateMovieRating command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpPost("/book-rating")]
        public async Task<IActionResult> Post([FromBody] CreateBookRating command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpPost("album-rating")]
        public async Task<IActionResult> Post([FromBody] CreateAlbumRating command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpPost("song-rating")]
        public async Task<IActionResult> Post([FromBody] CreateSongRating command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpGet("{movieId:guid}")]
        public async Task<IActionResult> GetMoviesRatings(Guid movieId)
        {
            return await Task.FromResult(Ok((_ratingRepository.ListAsNoTracking(x=>x.MovieId == movieId).ToVm())));
        }
        [HttpGet("{songId:guid}")]
        public async Task<IActionResult> GetSongsRatings(Guid songId)
        {
            return await Task.FromResult(Ok((_ratingRepository.ListAsNoTracking(x => x.SongId == songId).ToVm())));
        }
        [HttpGet("{bookId:guid}")]
        public async Task<IActionResult> GetBookRatings(Guid bookId)
        {
            return await Task.FromResult(Ok((_ratingRepository.ListAsNoTracking(x => x.BookId == bookId).ToVm())));
        }
        [HttpGet("{albumId:guid}")]
        public async Task<IActionResult> GetAlbumRatings(Guid albumId)
        {
            return await Task.FromResult(Ok((_ratingRepository.ListAsNoTracking(x => x.BookId == albumId).ToVm())));
        }

    }

}


