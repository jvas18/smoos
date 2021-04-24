using MediatR;
using Smoos.Domain.Users.ViewModels;

namespace Smoos.Domain.Users.Commands
{
    public class CreateUser: IRequest<UserVm>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }
        public EUserProfile UserProfile { get;set; }
    }
}
