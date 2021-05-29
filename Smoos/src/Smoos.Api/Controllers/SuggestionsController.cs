using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Suggestions.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuggestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSuggestion command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }
    }
}
