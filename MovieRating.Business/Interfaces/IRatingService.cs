using MovieRating.Domain.DTO;
using MovieRating.Domain.Enums.Validation;
using System.Threading.Tasks;

namespace MovieRating.Business.Interfaces
{
    public interface IRatingService
    {
        /// <summary>
        /// Validates the movieRating for saving
        /// </summary>
        /// <param name="movieRating"></param>
        /// <returns></returns>
        Task<MovieRatingSaveValidationResults> ValidateMovieRatingAsync(MovieRatings movieRating);

        /// <summary>
        /// Saves the rating.
        /// If the rating already exists it will be updated to the new value
        /// </summary>
        /// <param name="movieRating"></param>
        /// <returns>MovingRatingSaveResults indicate save outcome</returns>
        Task<bool> SaveRatingAsync(MovieRatings movieRating);

    }
}
