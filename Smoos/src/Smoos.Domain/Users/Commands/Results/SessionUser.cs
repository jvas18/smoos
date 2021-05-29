using Smoos.Domain.Common.Constants;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;

namespace Smoos.Domain.Users.Commands.Results
{
    public class SessionUser
    {
        public SessionUser()
        {
        }

        public SessionUser(Guid id, string email, string name, EUserProfile profile)
        {
            Id = id;
            Email = email;
            Name = name;
            Profile = profile;
        }

        public Guid Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; } 

        public string Avatar { get; set; }

        public EUserProfile Profile { get; set; }

        [JsonIgnore]
        public IEnumerable<Claim> Claims => new List<Claim>()
        {
            new Claim(CustomClaims.Id, Id.ToString()),
            new Claim(CustomClaims.Email, Email),
            new Claim(CustomClaims.Profile, Profile.ToString())
        };

        [JsonIgnore]
        public ClaimsIdentity Identity => new ClaimsIdentity(Claims);
    }
}
