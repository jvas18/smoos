using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Suggestions
{
    public interface ISuggestionRepository : IRepositoryBase<Suggestion, Guid>
    {
    }
}
