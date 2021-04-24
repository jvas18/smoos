using Microsoft.EntityFrameworkCore;
using Smoos.Domain.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Data.Repositories
{
    public class BookRepository : RepositoryBase<Book, Guid>, IBookRepository
    {
        public BookRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
