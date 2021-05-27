using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Albums
{
    public interface IAlbumRepository : IRepositoryBase<Album, Guid>
    {
    }
}
