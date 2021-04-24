using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Common.Contracts
{
    public interface IEntityType<TId> 
    {
        TId Id { get; }
    }
}
