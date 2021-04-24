using MediatR;
using Smoos.Domain.Users.Commands.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Users.Commands.Handlers
{
    public class LoginHandler : ILoginHandler
    {
        private readonly IUserRepository _userRepository;

        public LoginHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AuthenticatedUserResult> Handle(Login request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindAsNoTrackingAsync(x=>x.Email == request.Email);

            //if (user == null)
            //    throw new DomainException(AppMessages.InvalidCredentials);

            //if (!user.PasswordIsValid(request.Password))
            //    throw new DomainException(AppMessages.InvalidCredentials);

            return new AuthenticatedUserResult
            {
                SessionUser = new SessionUser
                {
                    Avatar = user.Picture,
                    Email = user.Email,
                    Id = user.Id,
                    Name = user.Name
                }
            };
        }
    }

    public interface ILoginHandler: IRequestHandler<Login, AuthenticatedUserResult>
    {
    }
}
