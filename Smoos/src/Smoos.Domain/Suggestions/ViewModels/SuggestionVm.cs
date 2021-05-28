using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Suggestions.ViewModels
{
    public class SuggestionVm 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
        public UserVm User { get; set; }
        public ECategory Category { get; set; }
    }
}
