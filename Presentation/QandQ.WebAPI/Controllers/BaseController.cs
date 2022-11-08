using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace QandQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IMediator? Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediatr;
    }
}
