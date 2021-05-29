using MediatR;
using Smoos.Domain.Artists.Projections;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Smoos.CrossCutting.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Artists.Command.Handlers
{
    public class CreateArtistHandler : ICreateArtistHandler
    {
        private readonly IArtistRepository _artistRepository;
        private IFileUtils _fileUtils;

        public CreateArtistHandler(IArtistRepository artistRepository, IFileUtils fileUtils)
        {
            _artistRepository = artistRepository;
            _fileUtils = fileUtils;
        }

        public async Task<ArtistVm> Handle(CreateArtist request, CancellationToken cancellationToken)
        {

            var artist = new Artist(Guid.NewGuid(), request.Name, request.Age, request.Description);
            string imageUrl;
            if (request.Photo?.HasValue() == true)
            {
                if (!string.IsNullOrEmpty(artist.Photo))
                    await _fileUtils.RemoveByUrlAsync(artist.Photo);

                var fileName = $"artists/{Guid.NewGuid()}{request.Photo.Name.GetExtension()}";

                imageUrl = await _fileUtils.UploadAsync(request.Photo, fileName);

                if (imageUrl.IsNull())
                    throw new Exception("Erro ao Importar o poster");
            }
            else
            {
                imageUrl = artist.Photo;
            }
            artist.Photo = imageUrl;

            await _artistRepository.AddAsync(artist);
            return artist.ToVm();
        }
    }

    public interface ICreateArtistHandler: IRequestHandler<CreateArtist, ArtistVm>
    {
    }
}
