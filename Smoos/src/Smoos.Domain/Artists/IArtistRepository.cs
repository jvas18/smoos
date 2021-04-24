using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Artists
{
    public interface IArtistRepository: IRepositoryBase<Artist, Guid>
    {
    }
}
