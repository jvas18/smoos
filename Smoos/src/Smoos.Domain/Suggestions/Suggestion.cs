using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Suggestions
{
    public class Suggestion : IEntityType<Guid>
    {
        public Suggestion(string name, Guid userId ,ECategory category)
        {
            Id = Guid.NewGuid();
            Name = name;
            UserId = userId;
            Category = category;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ECategory Category { get; set; }
    }
}
