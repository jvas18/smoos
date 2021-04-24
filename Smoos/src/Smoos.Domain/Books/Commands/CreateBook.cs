using MediatR;
using Smoos.Domain.Books.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Books.Commands
{
    public class CreateBook: IRequest<BookVm>
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Pages { get; set; }
        public string Summary { get; set; }
        public string Publisher { get; set; }
        public Guid ArtistId { get; set; }
    }
}
