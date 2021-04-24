using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Users.Projections
{
   public static class UserProjections
    {
        public static IQueryable<UserVm> ToVm(this IQueryable<User> query) =>
           query.Select(entity => new UserVm {
               Id = entity.Id,
               Name = entity.Name,
               Email = entity.Email,
               UserProfile = entity.UserProfile,
               Password = entity.Password,
               Picture = entity.Picture

           });

        public static IEnumerable<UserVm> ToVm(this IEnumerable<User> query) => query.AsQueryable().ToVm();
        public static UserVm ToVm(this User entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
