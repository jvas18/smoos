using Smoos.Domain.Common.Contracts;
using Smoos.Domain.Movies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Artists
{
   public class Artist: IEntityType<Guid>
    {

        public Artist(Guid id, string name, int age, string description)
        {
            Id = id;
            Name = name;
            Age = age;
            Description = description;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public ICollection<Movie> Movies = new List<Movie>();


        public string Description { get; private set; }

       
    }
}
