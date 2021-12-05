using Microsoft.AspNetCore.Mvc;
using MovieRating.Business.Interfaces;
using MovieRating.Domain.DTO;
using MovieRating.Domain.Enums.Validation;
using System.Threading.Tasks;

namespace MovieRating.API.Controllers
{
    /// <summary>
    /// Saves movie ratings
    /// </summary>
    [Produces("application/json")]
    [Route("api/SaveMovieRating")]
    public class SaveMovieRatingController : Controller
    {
        private readonly IRatingService _ratingService;

        
        /// <param name="ratingService"></param>
        public SaveMovieRatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        /// <summary>
        /// saves a movie rating
        /// </summary>
        /// <param name="movieRating"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(MovieRatings))]
        public async Task<IActionResult> Post([FromBody]MovieRatings movieRating)
        {
            var validationResult = await _ratingService.ValidateMovieRatingAsync(movieRating);

            switch (validationResult)
            {
                case MovieRatingSaveValidationResults.OK:
                    if (await _ratingService.SaveRatingAsync(movieRating))
                    {
                        return Ok();
                    }
                    else
                    {
                        return BadRequest("couldn't save rating");
                    }
                case MovieRatingSaveValidationResults.NullRating:
                case MovieRatingSaveValidationResults.InvalidMovieId:
                case MovieRatingSaveValidationResults.InvalidUserId:
                    return BadRequest(validationResult.ToString());
                case MovieRatingSaveValidationResults.MovieNotfound:
                case MovieRatingSaveValidationResults.UserNotFound:
                    return NotFound(validationResult.ToString());
            }
            return BadRequest("unknown validation failure");
        }

    }
}