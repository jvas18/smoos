using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Songs;
using Smoos.Domain.Songs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongRepository _songsRepository;
        private readonly IMediator _mediator;

        public SongsController(ISongRepository songsRepository, IMediator mediator)
        {
            _songsRepository = songsRepository;
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
