using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Users
{
    public interface IUserRepository : IRepositoryBase<User, Guid>
    {
    }
}
