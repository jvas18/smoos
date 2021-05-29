using Smoos.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Smoos.Domain.Common.Contracts
{
    public interface IJwtService
    {
        void Generate<T>(ClaimsIdentity identity, ref T jwToken)
           where T : JwToken;
    }
}
