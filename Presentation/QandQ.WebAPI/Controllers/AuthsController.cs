using Microsoft.AspNetCore.Mvc;
using QandQ.Application.Features.Auths.Commands.LoginUser;
using QandQ.Application.Features.Auths.Commands.RegisterUser;

namespace QandQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : BaseController
    {
        /// <summary>
        ///     Kullanıcı kayıt olur.
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommand registerUserCommand)
        {
            var result = await Mediator.Send(registerUserCommand);
            return Ok(result);
        }
        
        /// <summary>
        ///     Kullanıcı giriş yapar.
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommand loginUserCommand)
        {
            var result = await Mediator.Send(loginUserCommand);
            return Ok(result);
        }
    }
}
