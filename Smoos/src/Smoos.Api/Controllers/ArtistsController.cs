using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Artists;
using Smoos.Domain.Artists.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/artists")]
    [ApiController]
    public class ArtistsController: ControllerBase
    {
        private readonly IArtistRepository _artistRepository;
        private readonly IMediator _mediator;

        public ArtistsController(IArtistRepository artistRepository, IMediator mediator)
        {
            _artistRepository = artistRepository;
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateArtist command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
    }
}
