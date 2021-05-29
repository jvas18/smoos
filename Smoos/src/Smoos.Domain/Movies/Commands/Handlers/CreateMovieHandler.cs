using MediatR;
using Smoos.Domain.Artists;
using Smoos.Domain.Common;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
using Smoos.Domain.Movies.Projections;
using Smoos.Domain.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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
        private readonly IFileUtils _fileUtils;

        public CreateMovieHandler(IMovieRepository movieRepository, IArtistRepository artistRepository, IFileUtils fileUtils)
        {
            _movieRepository = movieRepository;
            _artistRepository = artistRepository;
            _fileUtils = fileUtils;
        }

        public async Task<MovieVm> Handle(CreateMovie request, CancellationToken cancellationToken)
        {
            var artists = _artistRepository.List(x => request.Actors.Contains(x.Id)).ToList();
            var movie = new Movie(Guid.NewGuid(), request.Name, request.ReleaseYear, request.Duration, request.Summary, request.Country, request.MovieGenres);
            movie.Actors = artists;
            string imageUrl;
            if (request.Poster?.HasValue() == true)
            {
                if (!string.IsNullOrEmpty(movie.Poster))
                    await _fileUtils.RemoveByUrlAsync(movie.Poster);

                var fileName = $"movies/{Guid.NewGuid()}{request.Poster.Name.GetExtension()}";

                imageUrl = await _fileUtils.UploadAsync(request.Poster, fileName);

                if (imageUrl.IsNull())
                    throw new Exception("Erro ao Importar o poster");
            }
            else
            {
                imageUrl = movie.Poster;
            }
            movie.Poster = imageUrl;
            movie = await _movieRepository.AddAsync(movie);
            return movie.ToVm();
        }
    }

    public interface ICreateMovieHandler: IRequestHandler<CreateMovie, MovieVm>
    {
    }
}
