using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QandQ.Application.Features.Auths.Dtos;
using QandQ.Application.LoginSecurity.Helper;
using QandQ.Application.Repositories.Users;
using QandQ.Domain.Entities;

namespace QandQ.Application.Features.Auths.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<RegisteredUserDto>
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public ICollection<CreateUserRoleDto> UserRoles { get; set; }

        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegisteredUserDto>
        {
            private readonly IUserWriteRepository _userWriteRepository;

            public RegisterUserCommandHandler(IUserWriteRepository userWriteRepository)
            {
                _userWriteRepository = userWriteRepository;
            }

            public async Task<RegisteredUserDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {

                HashingHelper.CreatePasswordHash(request.Password, out var passwordHash, out var passwordSalt);
                var user = request.Adapt<User>();
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;


                await _userWriteRepository.AddAsync(user);
                var result = await _userWriteRepository.SaveAsync();

                return result > 0 ? user.Adapt<RegisteredUserDto>() : null;
            }
        }
    }
}
