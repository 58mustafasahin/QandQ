using MediatR;
using Microsoft.EntityFrameworkCore;
using QandQ.Application.LoginSecurity.Entity;
using QandQ.Application.LoginSecurity.Helper;
using QandQ.Application.Repositories.UserRoles;
using QandQ.Application.Repositories.Users;
using QandQ.Domain.Entities;

namespace QandQ.Application.Features.Auths.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IUserReadRepository _userReadRepository;
            private readonly IUserRoleReadRepository _userRoleReadRepository;
            private readonly ITokenHelper _tokenHelper;

            public LoginUserCommandHandler(IUserReadRepository userReadRepository, IUserRoleReadRepository userRoleReadRepository, ITokenHelper tokenHelper)
            {
                _userReadRepository = userReadRepository;
                _userRoleReadRepository = userRoleReadRepository;
                _tokenHelper = tokenHelper;
            }

            public async Task<AccessToken?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var currentUser = await _userReadRepository.GetWhere(p => p.UserName == request.UserName).FirstOrDefaultAsync();
                if (currentUser == null) return null;
                var passwordMatchResult = HashingHelper.VerifyPasswordHash(request.Password, currentUser.PasswordHash, currentUser.PasswordSalt);
                return passwordMatchResult ? await CreateAccessToken(currentUser) : null;
            }

            public async Task<AccessToken?> CreateAccessToken(User user)
            {
                var currentUserRoles = await GetUserRolesByUserId(user.Id);
                return currentUserRoles == null ? null : _tokenHelper.CreateToken(user, currentUserRoles);
            }

            private async Task<IEnumerable<Role>> GetUserRolesByUserId(int id)
            {
                return await _userRoleReadRepository.GetWhere(p => p.UserId == id)
                .Include(p => p.Role).Select(p => p.Role).ToListAsync();
            }
        }
    }
}
