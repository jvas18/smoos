using MediatR;
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

        public CreateSongHandler(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<SongVm> Handle(CreateSong request, CancellationToken cancellationToken)
        {
            var song = await _songRepository.AddAsync(new Song(Guid.NewGuid(), request.Name, request.ReleaseYear, request.Duration, request.ArtistId));
            return song.ToVm();
        }
    }
}
