using MediatR;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Common.Security;
using Smoos.Domain.Users;
using Smoos.Domain.Users.Commands;
using Smoos.Domain.Users.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Smoos.Api.Controllers
{
    [Route("/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMediator _mediator;

        public UsersController(IUserRepository userRepository, IMediator mediator)
        {
            _userRepository = userRepository;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUser command)
        {
            return command == null ?
              UnprocessableEntity()
              : Ok(await _mediator.Send(command));
        }

        

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var project =_userRepository.ListAsNoTracking(x => x.Id == id).ToVm().FirstOrDefault();

            return await Task.FromResult(
               Ok(project));
        }


    }
}
