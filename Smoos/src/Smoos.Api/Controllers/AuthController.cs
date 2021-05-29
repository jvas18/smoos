using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Smoos.Domain.Common._Config;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Common.Security;
using Smoos.Domain.Users;
using Smoos.Domain.Users.Commands;
using Smoos.Domain.Users.Commands.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Smoos.Api.Controllers
{
    [Route("/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;

        public AuthController(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] AuthenticateUser command,
            [FromServices] IJwtService tokenService)
        {
            if (command == null) return UnprocessableEntity();


            //TODO implementar busca de usuário por email
            User user = await _userRepository.FindAsNoTrackingAsync(x=> x.Email == command.Email);
            //User user = await _userRepository.FindFromLoginAsync(command.Email, command.Password);


            var result = new AuthenticatedUserResult();


            result.SessionUser = new SessionUser(
                id: user.Id,
                email: user.Email,
                name: user.Name,
                profile: user.UserProfile
            );


            tokenService.Generate(result.SessionUser.Identity, ref result);

            return Ok(result);
        }
    }
}
