using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Movies;
using Smoos.Domain.Movies.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/movies")]
    [ApiController]
    public class MoviesController: ControllerBase
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMediator _mediator;

        public MoviesController(IMovieRepository movieRepository, IMediator mediator)
        {
            _movieRepository = movieRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateMovie command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
    }
}
