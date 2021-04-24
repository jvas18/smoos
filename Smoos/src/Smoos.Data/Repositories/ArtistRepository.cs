using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Artists;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class ArtistRepository : RepositoryBase<Artist, Guid>, IArtistRepository
    {
        public ArtistRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
