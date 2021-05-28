using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Ratings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class RatingRepository : RepositoryBase<Rating, Guid>, IRatingRepository
    {
        public RatingRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
