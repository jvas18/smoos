using MediatR;
using Smoos.Domain.Albums.Projections;
using Smoos.Domain.Albums.ViewModels;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Albums.Commands.Handler
{
    public class CreateAlbumHandler : IRequestHandler<CreateAlbum, AlbumVm>
    {
        private readonly IAlbumRepository _albumRepository;
        private IFileUtils _fileUtils;

        public CreateAlbumHandler(IAlbumRepository albumRepository, IFileUtils fileUtils)
        {
            _albumRepository = albumRepository;
            _fileUtils = fileUtils;
        }

        public async Task<AlbumVm> Handle(CreateAlbum request, CancellationToken cancellationToken)
        {
            var album = new Album(Guid.NewGuid(), request.Name, request.ReleaseYear,request.Duration, request.ArtistId.Value);
            string imageUrl;
            if (request.Poster?.HasValue() == true)
            {
                if (!string.IsNullOrEmpty(album.Poster))
                    await _fileUtils.RemoveByUrlAsync(album.Poster);

                var fileName = $"albums/{Guid.NewGuid()}{request.Poster.Name.GetExtension()}";

                imageUrl = await _fileUtils.UploadAsync(request.Poster, fileName);

                if (imageUrl.IsNull())
                    throw new Exception("Erro ao Importar o poster");
            }
            else
            {
                imageUrl = album.Poster;
            }
            album.Poster = imageUrl;

            await _albumRepository.AddAsync(album);
            return album.ToVm();
        }
    }
}
