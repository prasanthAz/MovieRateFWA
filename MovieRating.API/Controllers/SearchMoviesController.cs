using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interfaces;
using MovieRating.Domain.DTO;
using MovieRating.Domain.Enums.Validation;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRating.API.Controllers
{
    /// <summary>
    /// Movie search
    /// </summary>
    [Produces("application/json")]
    [Route("api/SearchMovies")]
    public class SearchMoviesController : Controller
    {
        private readonly IMovieService _movieService;

        
        /// <param name="movieService"></param>
        public SearchMoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Searches movies by given criteria
        /// Note: at least one field of the criteria object must be set
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Movie>))]
        public async Task<IActionResult> Get(MovieSearchCriteria criteria)
        {
            var validationResult = _movieService.ValidateSearchCriteria(criteria);

            switch (validationResult)
            {
                case MovieSearchValidationResults.InvalidCriteria:
                case MovieSearchValidationResults.NoCriteria:
                    return BadRequest(validationResult.ToString());                
            }

            var movies = await _movieService.SearchMoviesAsync(criteria);

            if (movies == null || !movies.Any())
            {
                return NotFound();
            }

            return Json(movies);
        }

    }
}