using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QandQ.Application.Features.Movies.Commands.SuggestMovie;
using QandQ.Application.Features.Movies.Queries.GetAllMovie;
using QandQ.Application.Features.Movies.Queries.GetByIdMovie;

namespace QandQ.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : BaseController
    {
        /// <summary>
        ///     Tüm filmleri getirir.
        /// </summary>
        /// <remarks>
        ///     Sayfalama ile istenilen sayfa ve istelen veri sayısı kadar film getirir.
        ///     Eğer bu veriler gönderilmezse başlangıç olarak 1.sayfadaki ilk 10 veri getirilir.
        /// </remarks>      
        [HttpPost("[action]")]
        public async Task<IActionResult> GetAll(GetAllMovieQuery getAllMovieQuery)
        {
            var result = await Mediator.Send(getAllMovieQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Film Id'ye göre detayları getirir.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById([FromQuery] GetByIdMovieQuery getByIdMovieQuery)
        {
            var result = await Mediator.Send(getByIdMovieQuery);
            return Ok(result);
        }

        /// <summary>
        ///     Mail adresine film önerisi gönderir. !!!!! Not: Gmail artık güvensiz uygulamalara mail gönderimine izin vermiyor.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SuggestMovie(SuggestMovieCommand suggestMovieCommand)
        {
            var result = await Mediator.Send(suggestMovieCommand);
            return Ok(result);
        }
    }
}
