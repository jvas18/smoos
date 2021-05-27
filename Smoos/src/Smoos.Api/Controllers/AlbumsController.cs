using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Albums;
using Smoos.Domain.Songs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/songs")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IAlbumRepository _albumRepository;
        private readonly IMediator _mediator;

        public AlbumsController(IAlbumRepository albumRepository, IMediator mediator)
        {
            _albumRepository = albumRepository;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSong command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
    }
}
