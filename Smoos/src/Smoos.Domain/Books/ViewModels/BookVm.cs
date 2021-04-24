using Smoos.Domain.Artists.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Books.ViewModels
{
    public class BookVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public ArtistVm Author { get; set; }
        public string Pages { get; set; }
        public string Summary { get; set; }
        public string Publisher { get; set; }
        public Guid ArtistId { get; set; }
    }
}
