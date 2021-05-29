using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Artists;
using Smoos.Domain.Artists.Command;
using Smoos.Domain.Artists.Projections;
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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok((_artistRepository.ListAsNoTracking().ToVm())));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await Task.FromResult(Ok((_artistRepository.ListAsNoTracking(x => x.Id == id).FirstOrDefault().ToVm())));
        }
    }
}
