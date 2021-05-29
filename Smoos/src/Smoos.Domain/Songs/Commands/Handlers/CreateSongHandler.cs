using MediatR;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
using Smoos.Domain.Songs.Projections;
using Smoos.Domain.Songs.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Songs.Commands.Handlers
{
    public class CreateSongHandler : IRequestHandler<CreateSong, SongVm>
    {
        private readonly ISongRepository _songRepository;
        private IFileUtils _fileUtils;

        public CreateSongHandler(ISongRepository songRepository, IFileUtils fileUtils)
        {
            _songRepository = songRepository;
            _fileUtils = fileUtils;
        }

        public async Task<SongVm> Handle(CreateSong request, CancellationToken cancellationToken)
        {
            var song = new Song(Guid.NewGuid(),request.Name,request.AlbumId, request.ReleaseYear, request.Duration, request.ArtistId);
            string imageUrl;
            if (request.Poster?.HasValue() == true)
            {
                if (!string.IsNullOrEmpty(song.Poster))
                    await _fileUtils.RemoveByUrlAsync(song.Poster);

                var fileName = $"songs/{Guid.NewGuid()}{request.Poster.Name.GetExtension()}";

                imageUrl = await _fileUtils.UploadAsync(request.Poster, fileName);

                if (imageUrl.IsNull())
                    throw new Exception("Erro ao Importar o poster");
            }
            else
            {
                imageUrl = song.Poster;
            }
            song.Poster = imageUrl;
            await _songRepository.AddAsync(song);

            return song.ToVm();
        }
    }
}
