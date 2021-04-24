using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Common.Contracts.Persistance;
using Smoos.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
