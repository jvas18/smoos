using MediatR;
using Smoos.Domain.Albums.Projections;
using Smoos.Domain.Albums.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Albums.Commands.Handler
{
    public class CreateAlbumHandler : IRequestHandler<CreateAlbum, AlbumVm>
    {
        private readonly IAlbumRepository _albumRepository;

        public CreateAlbumHandler(IAlbumRepository albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<AlbumVm> Handle(CreateAlbum request, CancellationToken cancellationToken)
        {
            var album = await _albumRepository.AddAsync(new Album(Guid.NewGuid(), request.Name, request.ReleaseYear,request.Duration, request.ArtistId));
            return album.ToVm();
        }
    }
}
