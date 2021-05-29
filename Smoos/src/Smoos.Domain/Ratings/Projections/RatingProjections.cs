using Smoos.Domain.Ratings.ViewModels;
using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Ratings.Projections
{
    public static class RatingProjections
    {
        public static IQueryable<RatingVm> ToVm(this IQueryable<Rating> query) =>
                    query.Select(entity => new RatingVm
                    {
                        Id = entity.Id,
                        Comment = entity.Comment,
                        Stars = entity.Stars,
                        UserId = entity.UserId,
                        User = entity.User == null? null : new UserVm
                        {
                            Id = entity.UserId,
                            Name = entity.User.Name
                        },
                        Title = entity.Title,
                        CreatedAt = entity.CreatedAt


                    });

        public static IEnumerable<RatingVm> ToVm(this IEnumerable<Rating> query) => query.AsQueryable().ToVm();
        public static RatingVm ToVm(this Rating entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
