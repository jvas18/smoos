using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Artists.ViewModels
{
    public class ArtistVm
    {
        public Guid Id { get;  set; }
        public string Name { get;  set; }
        public int Age { get;  set; }
        public string Description { get;  set; }
    }
}
