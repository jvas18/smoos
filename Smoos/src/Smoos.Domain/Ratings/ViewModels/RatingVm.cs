using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Ratings.ViewModels
{
    public class RatingVm
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public UserVm User { get; set; }
        public Guid UserId { get; set; }
    }
}
