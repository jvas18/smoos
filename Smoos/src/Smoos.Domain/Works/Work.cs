using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Ratings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Works
{
    public class Work : IEntityType<Guid>
    {
        public Work(Guid id, string name, string releaseYear)
        {
            Id = id;
            Name = name;
            ReleaseYear = releaseYear;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReleaseYear { get; set; }
        public decimal Rate { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
