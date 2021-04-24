using Smoos.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Users.Commands.Results
{
    public class AuthenticatedUserResult : JwToken
    {
        public SessionUser SessionUser { get; set; }
    }
}
