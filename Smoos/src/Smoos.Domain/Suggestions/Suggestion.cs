using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Suggestions
{
    public class Suggestion : IEntityType<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ECategory Category { get; set; }
    }
}
