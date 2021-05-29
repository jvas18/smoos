using MediatR;
using Smoos.Domain.Users.Commands.Results;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Smoos.Domain.Users.Commands
{
    public class AuthenticateUser : IRequest<AuthenticatedUserResult>
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
