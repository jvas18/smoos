using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Suggestions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class SuggestionRepository : RepositoryBase<Suggestion, Guid>, ISuggestionRepository
    {
        public SuggestionRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
