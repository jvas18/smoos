using Smoos.Domain.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smoos.Domain.Users
{
    public class User : IEntityType<Guid>
    {
        public User(Guid id, string name, string email, string password, string picture, EUserProfile userProfile)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            Picture = picture;
            UserProfile = userProfile;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Picture { get; private set; }
        public EUserProfile UserProfile { get; private set; }
    }
}
