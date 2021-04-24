using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Books
{
    public interface IBookRepository: IRepositoryBase<Book, Guid>
    {
    }
}
