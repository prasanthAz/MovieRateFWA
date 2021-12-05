using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interfaces;
using MovieRating.Domain.DTO;
using System.Threading.Tasks;

namespace MovieRating.API.Controllers
{
    /// <summary>
    /// movie rating controller
    /// </summary>
    [Produces("application/json")]
    [Route("api/Movie")]
    public class MovieController : Controller
    {

        private readonly IMovieService _movieService;

       
        /// <param name="movieService"></param>
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Note: only for setting the data to local db ,remove id field 
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Movie))]
        public async Task<IActionResult> Post([FromBody]Movie movie)
        {
            if (await _movieService.SaveMovieAsync(movie))
            {
                return Ok();
            }
            else
            {
                return BadRequest("unable to save movie");
            }
        }

    }
}