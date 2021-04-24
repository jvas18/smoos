using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Users.ViewModels
{
    public class UserVm
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public EUserProfile UserProfile { get; set; }
    }
}

