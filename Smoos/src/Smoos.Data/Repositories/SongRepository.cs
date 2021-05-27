using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Songs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class SongRepository : RepositoryBase<Song, Guid>, ISongRepository
    {
        public SongRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
