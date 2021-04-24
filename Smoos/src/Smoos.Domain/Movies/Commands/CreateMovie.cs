using MediatR;
using Smoos.Domain.Movies.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Movies.Commands
{
    public class CreateMovie: IRequest<MovieVm>
    {
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public string Duration { get; set; }
        public ICollection<Guid> Actors { get; set; }
        public string Summary { get; set; }
        public string Country { get; set; }
        public EMovieGenre MovieGenres { get; set; }
    }
}
