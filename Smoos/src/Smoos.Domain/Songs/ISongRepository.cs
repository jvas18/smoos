using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Songs
{
    public interface ISongRepository : IRepositoryBase<Song, Guid>
    {
    }
}
