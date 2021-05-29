using MediatR;
using Smoos.Domain.Artists.ViewModels;
using Smoos.Domain.Common;

namespace Smoos.Domain.Artists.Command
{
    public class CreateArtist: IRequest<ArtistVm>
    {
        public string Name { get;  set; }
        public int Age { get;  set; }
        public FileInput Photo { get; set; }
        public string Description { get; set; }
    }
}
