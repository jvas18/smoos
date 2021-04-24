using Smoos.Domain.Common.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Movies
{
    public interface IMovieRepository: IRepositoryBase<Movie, Guid>
    {
       
    }
}
