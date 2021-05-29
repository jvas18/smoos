using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Albums;
using Smoos.Domain.Albums.Commands;
using Smoos.Domain.Albums.Projections;
using Smoos.Domain.Songs.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("albums")]
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
        public async Task<IActionResult> Post([FromBody] CreateAlbum command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return await Task.FromResult(Ok(_albumRepository.ListAsNoTracking().ToVm()));
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return await Task.FromResult(Ok((_albumRepository.ListAsNoTracking(x => x.Id == id).Include(x => x.Singer).Include(x=>x.Ratings).ToVm().FirstOrDefault())));
        }
    }
}
