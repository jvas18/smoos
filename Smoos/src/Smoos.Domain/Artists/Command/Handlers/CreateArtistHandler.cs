using MediatR;
using Smoos.Domain.Artists.Projections;
using Smoos.Domain.Artists.ViewModels;
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

        public CreateArtistHandler(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<ArtistVm> Handle(CreateArtist request, CancellationToken cancellationToken)
        {
            var artist = await _artistRepository.AddAsync(new Artist(Guid.NewGuid(), request.Name, request.Age, request.Description));

            return artist.ToVm();
        }
    }

    public interface ICreateArtistHandler: IRequestHandler<CreateArtist, ArtistVm>
    {
    }
}
