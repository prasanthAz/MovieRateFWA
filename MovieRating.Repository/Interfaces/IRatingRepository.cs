using MovieRating.Domain.DTO;
using System.Threading.Tasks;

namespace MovieRating.Repository.Interfaces
{
    public interface IRatingRepository
    {
        /// <summary>
        /// Saves the rating.
        /// If the rating already exists it will be updated to the new value
        /// </summary>
        /// <param name="movieRating"></param>
        /// <returns>true if save successful, false if not</returns>
        Task<bool> SaveRatingAsync(MovieRatings movieRating);

    }
}
