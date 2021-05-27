using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Albums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class AlbumRepository : RepositoryBase<Album, Guid>, IAlbumRepository
    {
        public AlbumRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
