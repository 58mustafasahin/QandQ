using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QandQ.Application.Features.RateAndNoteMovies.Commands.CreateRateAndNoteMovie;

namespace QandQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RateAndNoteMoviesController : BaseController
    {
        /// <summary>
        ///     Filmi oylanır ve not eklenir.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(CreateRateAndNoteMovieCommand createRateAndMovieCommand)
        {
            var result = await Mediator.Send(createRateAndMovieCommand);
            return Ok(result);
        }
    }
}
