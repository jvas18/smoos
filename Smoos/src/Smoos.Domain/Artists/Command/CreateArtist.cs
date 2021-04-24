using MediatR;
using Smoos.Domain.Artists.ViewModels;

namespace Smoos.Domain.Artists.Command
{
    public class CreateArtist: IRequest<ArtistVm>
    {
        public string Name { get;  set; }
        public int Age { get;  set; }
        public string Description { get; set; }
    }
}
