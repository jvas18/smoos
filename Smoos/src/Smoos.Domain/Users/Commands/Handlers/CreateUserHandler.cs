using MediatR;
using Smoos.Domain.Common;
using Smoos.Domain.Users.Projections;
using Smoos.Domain.Users.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smoos.Domain.Users.Commands.Handlers
{
    public class CreateUserHandler : ICreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserVm> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            try
            {
                if (await _userRepository.AnyAsync(x => x.Email == request.Email))
                    throw new Exception("Email já cadastrado");
            }
            catch(Exception e)
            {

            }

            var password = PasswordUtils.Hash(request.Password);
            var user = await _userRepository.AddAsync(new User(Guid.NewGuid(), request.Name, request.Email, password, request.Picture, request.UserProfile));

            return user.ToVm();

        }
    }

    public interface ICreateUserHandler : IRequestHandler<CreateUser, UserVm>
    {
    }
}
