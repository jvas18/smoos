using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Movies;
using System;

namespace Smoos.Data.Repositories
{
    public class MovieRepository : RepositoryBase<Movie, Guid>, IMovieRepository
    {
        public MovieRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
