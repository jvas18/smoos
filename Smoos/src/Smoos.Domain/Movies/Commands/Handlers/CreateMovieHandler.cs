using MediatR;
using Smoos.Domain.Artists;
using Smoos.Domain.Movies.Projections;
using Smoos.Domain.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Movies.Commands.Handlers
{
    public class CreateMovieHandler : ICreateMovieHandler
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IArtistRepository _artistRepository;

        public CreateMovieHandler(IMovieRepository movieRepository, IArtistRepository artistRepository)
        {
            _movieRepository = movieRepository;
            _artistRepository = artistRepository;
        }

        public async Task<MovieVm> Handle(CreateMovie request, CancellationToken cancellationToken)
        {
            var artists = _artistRepository.List(x => request.Actors.Contains(x.Id)).ToList();
            var movie = new Movie(Guid.NewGuid(), request.Name, request.ReleaseYear, request.Duration, request.Summary, request.Country, request.MovieGenres);
            movie.Actors = artists;
            movie = await _movieRepository.AddAsync(movie);
            return movie.ToVm();
        }
    }

    public interface ICreateMovieHandler: IRequestHandler<CreateMovie, MovieVm>
    {
    }
}
