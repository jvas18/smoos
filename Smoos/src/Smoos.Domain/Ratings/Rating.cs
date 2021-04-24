using Smoos.Domain.Artists;
using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Users;
using Smoos.Domain.Works;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings
{
    public class Rating : IEntityType<Guid>
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}