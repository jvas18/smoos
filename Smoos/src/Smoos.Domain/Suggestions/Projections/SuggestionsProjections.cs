using Smoos.Domain.Suggestions.ViewModels;
using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Smoos.Domain.Suggestions.Projections
{
    public static class SuggestionsProjections
    {
        public static IQueryable<SuggestionVm> ToVm(this IQueryable<Suggestion> query) =>
          query.Select(entity => new SuggestionVm
          {
              Id = entity.Id,
              Name = entity.Name,
              Category = entity.Category,
              UserId = entity.UserId,
              User = entity.User == null? null : new UserVm
              {
                  Id = entity.UserId
              }

          });
        public static IEnumerable<SuggestionVm> ToVm(this IEnumerable<Suggestion> query) => query.AsQueryable().ToVm();
        public static SuggestionVm ToVm(this Suggestion entity) => new[] { entity }.AsQueryable().ToVm().FirstOrDefault();
    }
}
